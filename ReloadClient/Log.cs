using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadClient
{
    class Log
    {
        public string LogPath { get; set; }
        public bool Append { get; set; }
        private bool firstrun = true;


        public void toFile(DateTime timeStamp, double current, double voltage, double resistance, double power, double cumPower, double cumCurrent)
        {
            string path = LogPath;
            string filename = DateTime.Now.ToString("yyy-MM-dd") + "_reloadPro" + ".log";
            try
            {
                if (firstrun == true)
                {
                    PrepareFile(path, filename);
                }
                // Write to the file:
                
                StreamWriter log = new StreamWriter(path + filename, true);
                log.Write(timeStamp.ToString());
                log.Write(";");
                log.Write(current.ToString());
                log.Write(";");
                log.Write(voltage.ToString());
                log.Write(";");
                log.Write(resistance.ToString());
                log.Write(";");
                log.Write(power.ToString());
                log.Write(";");
                log.Write(cumPower.ToString());
                log.Write(";");
                log.Write(cumCurrent.ToString());
                log.WriteLine();
                log.Close();
            }
            catch (Exception exp)
            {
                throw new System.Exception(exp.ToString());
            }
        }
        private void PrepareFile(string path, string filename)
        {
            try
            {
                firstrun = false;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    if (File.Exists(path + filename) && Append == false)
                    {
                        File.Delete(path + filename);
                    }
                    if (File.Exists(path + filename) == false)
                    {
                        StreamWriter log = new StreamWriter(path + filename);
                        log.Write("DateTime;Current;Voltage;Resistance;Power;CumPower;CumMah");
                        log.WriteLine();
                        log.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                throw new System.Exception(exp.ToString());
            }
        }
    }
}
