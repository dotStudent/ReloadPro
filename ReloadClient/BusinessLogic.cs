using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadClient
{
    class BusinessLogic
    {
        #region Getter/Setter
        public int Baudrate { get; set; } = 115200;
        
        public string SetPort { get; set; }
        public int SetInterval { get; set; }
        //public bool Stop { get; set; } = true;
        public bool Stopped { get; private set; } = true;
        public OperationsMode OpMode { get; set; }
        public Double InputValue { get; set; }
        public int ShutdownVoltageMV { get; set; }
        public Double CumulatedMAh { get { return Math.Round(CumMAh, 4); } }
        public Double CumulatedAh { get { return Math.Round(CumulatedMAh / 1000, 2); } }
        public Double CumulatedMWh { get { return Math.Round(CumMWh, 4); } }
        public Double CumulatedWh { get { return Math.Round(CumulatedMWh / 1000, 2); } }
        private SerialPort ComPort;
        public bool doLog { get; set;} =false;
        public string logPath { get; set; }
        public bool appendLogFile { get; set; } = true;
        #endregion

        #region Queues
        public Queue<ReloadReceiveData> ReadMessageQueue;
        #endregion
        

        
        private Double SetValue;
        private Double OldInputValue;
        private double LastMVoltage;
        private double LastMAmpere;
        private double LastResistance;
        private Double CumMAh;
        private Double CumMWh;
        Log log = new Log();
        
        #region Public Methods
        public void Start()
        {
            ReadMessageQueue = new Queue<ReloadReceiveData>();
            ComPort = new SerialPort();
            if (ReloadSerial.SerialPorts.Contains(SetPort))
            {
                log.LogPath = logPath;
                ComPort.PortName = SetPort;
                ComPort.BaudRate = Baudrate;
                ComPort.Open();
                ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);
                SetValue = InputValue;
                //ComPort.WriteLine("reset");
                //ComPort.WriteLine("on");
                //ComPort.Write("uvlo " + ShutdownVoltageMV);
                ComPort.WriteLine("monitor " + SetInterval);
            }
        }
        public void StopIt()
        {
            if (ComPort != null && ComPort.IsOpen == true)
            {
                ComPort.WriteLine("set 0");
                OldInputValue = 0;
                Stopped = true;
                ComPort.Close();
            }
        }
        #endregion

        #region Private Methods
        private void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReloadReceiveData rd = new ReloadReceiveData(ComPort.ReadLine());
            ReadMessageQueue.Enqueue(rd);

            LastMAmpere = rd.CurrentMA;
            LastMVoltage = rd.VoltageMV;
            LastResistance = rd.Resistance;
            CumMWh += GetHourlyValues(rd.PowerMW);
            CumMAh += GetHourlyValues(rd.CurrentMA);
            if (doLog == true)
            {
                log.toFile(rd.TimeStamp, rd.CurrentMA, rd.VoltageMV, rd.Resistance, rd.PowerMW, this.CumulatedMWh, this.CumulatedMAh);
            }

            if (rd.MessageType == MsgType.Read)
            {
                double newValue = Math.Round(CalcSetValue(),0); //check next Current Value to Set
                if (newValue != OldInputValue) // Check if user Changed Input Value
                {
                    InputValue = newValue;
                    OldInputValue = InputValue;
                    ComPort.WriteLine("set " + Math.Round(newValue, 0));
                }
            }
        }
        private double CalcSetValue()
        {
            if (OpMode == OperationsMode.ConstantVoltage)
            {
                if (LastMVoltage != SetValue)
                {
                    if (LastResistance != 0)
                    {
                        return Convert.ToDouble((SetValue * 1000) / LastResistance);
                    }
                    else
                    {
                        return 10;
                    }
                }
            }
            else if (OpMode == OperationsMode.ConstantResistance)
            {
                if (LastResistance != SetValue)
                {
                    return Convert.ToDouble(LastMVoltage / SetValue/1000);
                }
            }
            else if (OpMode == OperationsMode.ConstantPower)
            {
                if (InputValue != (LastMVoltage/1000 * LastMAmpere ))
                {
                    double val = Convert.ToInt32(InputValue / (LastMVoltage / 1000)*1000);
                    return Convert.ToDouble(InputValue / (LastMVoltage/1000)*1000);
                }
            }
            return SetValue;

            
            //Calc new Value for various Operation Modes
        }
        private double GetHourlyValues(double value)
        {
            double seconds = SetInterval / 1000;
            double multiplicator = seconds / 3600;
            double returnValue = value * multiplicator;
            return returnValue;
        }
        #endregion
    }
}
