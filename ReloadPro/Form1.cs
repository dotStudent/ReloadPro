using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Text.RegularExpressions;



namespace ReloadPro
{
    public partial class Form1 : Form
    {
        decimal totcurrent;
        decimal power;
        int interval;
        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
 //           serialPort1.PortName = "COM15"; 
 //           serialPort1.BaudRate = 115200;        
 //           serialPort1.Open();
 //           serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            interval = Convert.ToInt32(textBox3.Text);
            string current = textBox5.Text;
            int int_interval = 1000;
            int int_current = 100;
            bool ok_interval = false;
            bool ok_current = false;

            try
            {
                int_current = Convert.ToInt32(current);
                if ((int_current < Int32.MaxValue) && (int_current < 4000))
                {
                    ok_current = true;
                    //serialPort1.WriteLine("set " + current);
                }
            }
            catch (FormatException)
            {
                textBox2.Text = "Falscher Stromwert";
            }
            catch (OverflowException)
            {
                Console.WriteLine("Zu hoher Stromwert");
            }
  

            try
            {
                int_interval = Convert.ToInt32(interval);
                if (int_interval < Int32.MaxValue)
                {
                    ok_interval = true;
                    //serialPort1.WriteLine("monitor " + interval);
                }
            }
            catch (FormatException)
            {
                textBox2.Text = "Falscher Intervallwert";
            }
            catch (OverflowException)
            {
                Console.WriteLine("Zu hoher Intervallwert");
            }

            if (ok_current == true && ok_interval == true)
            {
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.BaudRate = Properties.Settings.Default.Baudrate;
                serialPort1.Open();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                serialPort1.WriteLine("set " + current);
                serialPort1.WriteLine("monitor " + interval);
                textBox1.Text = "Lesen angefordert!";
                buttonOn.Enabled = false;
                buttonOff.Enabled = true;
            }
            else
            {
                textBox2.Text = "Problem mit Eingabewerten!";
            }
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("monitor 0");
            textBox1.Text = "Stop";
            serialPort1.Close();
            buttonOn.Enabled = true;
            buttonOff.Enabled = false;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    string RxString = serialPort1.ReadLine();

                    Numbers.F_number = RxString;
                    Invoke(new MethodInvoker(reload_return));
                }
                catch
                {
                    serialPort1.Close();
                }
                
            }
        }
        void reload_return()
        {
            string current = "0";
            string voltage= "0";
            if (Numbers.F_number.StartsWith("err"))
            {
                Log(Numbers.F_number);
                textBox2.Text = DateTime.Now.ToString() + " " + Numbers.F_number.Remove(0, 4);
            }
            if (Numbers.F_number.StartsWith("set"))
            {
                textBox4.AppendText(Numbers.F_number);
                textBox4.AppendText(" mA");
                textBox4.AppendText(Environment.NewLine);
                Log(Numbers.F_number);
                textBox5.Text = Numbers.F_number.Remove(0,4);
            }
            if (Numbers.F_number.StartsWith("read"))
            {
                string[] read = Regex.Split(Numbers.F_number, " ");
                current = read[1];
                voltage = read[2];
                voltage = voltage.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                textBox4.AppendText(current);
                textBox4.AppendText(" mA, ");
                textBox4.AppendText(voltage);
                textBox4.AppendText(" mV");
                textBox4.AppendText(Environment.NewLine);
                //MessageBox.Show(current + " " + voltage);
                Log(Numbers.F_number);
            }
            else
            {
                textBox4.AppendText(Numbers.F_number);
                textBox4.AppendText(Environment.NewLine);
                Log(Numbers.F_number);
            }
            if ((Convert.ToDecimal(current) > 0) && (Convert.ToDecimal(voltage) > 0))
            {
                totcurrent = totcurrent + Convert.ToDecimal(current) * interval / 3600000;
                power = power + Convert.ToDecimal(current) * Convert.ToDecimal(voltage) / 1000 * interval / 3600000;

                label11.Text = (Convert.ToString(Math.Round(Convert.ToDecimal(voltage) / Convert.ToDecimal(current), 2))) + " Ω";
                label15.Text = (Convert.ToString(Math.Round(Convert.ToDecimal(voltage)/1000,2))) + " V";
                label17.Text = (Convert.ToString(Math.Round(Convert.ToDecimal(current), 2))) + " mA";
                label13.Text = (Convert.ToString(Math.Round(Convert.ToDecimal(voltage)/1000 * Convert.ToDecimal(current)/1000, 2))) + " W";
                if (totcurrent < 1000)
                {
                    label8.Text = (Convert.ToString(Math.Round(totcurrent, 2))) + (" mAh");
                }
                else if (totcurrent >= 1000)
                {
                    label8.Text = (Convert.ToString(Math.Round(totcurrent / 1000, 2))) + (" Ah");
                }
                if (power < 1000)
                {
                    label9.Text = (Convert.ToString(Math.Round(power, 2))) + (" mWh");
                }
                else if (power >= 1000)
                {
                    label9.Text = (Convert.ToString(Math.Round(power / 1000, 2))) + (" Wh");
                }
            }
            
        }
        static void Log(string Message)
        {
            try
            {
                StreamWriter log;
                string path = Properties.Settings.Default.LogPath;
                string filename = DateTime.Now.ToString("yyy-MM-dd") +"_reloadPro" + ".log";

                // Erstelle Log Ordner falls nicht vorhanden
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Erstelle Logfile falls nicht vorhanden
                if (!File.Exists(path + filename))
                {
                    log = new StreamWriter(path + filename);
                }
                // Wenn Datei vorhanden, neue Einträge anhängen
                else
                {
                    log = File.AppendText(path + filename);
                }
                // Write to the file:
                log.Write(DateTime.Now.ToString());
                log.Write(" ");
                log.Write(Message);
                log.WriteLine();
                log.Close();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

    }
    public class Numbers
    {
        public static string F_number;
    }
}

