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
        public string[] SerialPorts { get { return Serial.GetPorts(); } }
        public string SetPort { get; set; }
        public int SetInterval { get; set; }
        public bool Stop { get; set; } = true;
        public bool Stopped { get; private set; } = true;
        public OperationsMode OpMode { get; set; }
        public Double InputValue { get; set; }
        public int ShutdownVoltageMV { get; set; }
        public Double CumulatedMAh { get { return Math.Round(CumMAh, 4); } }
        public Double CumulatedAh { get { return Math.Round(CumulatedMAh / 1000, 2); } }
        public Double CumulatedMWh { get { return Math.Round(CumMWh, 4); } }
        public Double CumulatedWh { get { return Math.Round(CumulatedMWh / 1000, 2); } }
        #endregion

        #region Queues
        public Queue<ReloadReceiveData> ReadMessageQueue;
        //public Queue<ReloadSendData> WriteMessageQueue;
        #endregion

        private SerialPort ComPort;
        private Double SetValue;
        private Double OldInputValue;
        private double LastMVoltage;
        private double LastMAmpere;
        private double LastResistance;
        private Double CumMAh;
        private Double CumMWh;

        #region Public Methods
        public void Start()
        {
            ReadMessageQueue = new Queue<ReloadReceiveData>();
            ComPort = new SerialPort();
            if (SerialPorts.Contains(SetPort))
            {
                ComPort.PortName = SetPort;
                ComPort.BaudRate = Baudrate;
                ComPort.Open();
                ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);
                OldInputValue = InputValue;
                SetValue = InputValue;
                ComPort.WriteLine("set " + CalcFirstInputValue());
                Stop = false;
                ComPort.WriteLine("monitor " + SetInterval);
            }
        }
        public void StopIt()
        {
            if (ComPort != null)
            {
                ComPort.WriteLine("set " + "0");
                Stopped = true;
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

            if (rd.MessageType == MsgType.Read)
            {
                if (ShutdownVoltageMV >= LastMVoltage || Stop == true)
                {
                    StopIt();
                }
                double newValue = Math.Round(CalcSetValue(),0); //check next Current Value to Set
                if (newValue != OldInputValue) // Check if user Changed Input Value
                {
                    InputValue = newValue;
                    OldInputValue = InputValue;
                    ComPort.WriteLine("set " + Math.Round(newValue, 0));

                }


                //if (newValue != -1)
                //{
                //    ComPort.WriteLine("set " + Math.Round(newValue,0));
                //}
            }
        }
        private Double CalcFirstInputValue()
        {
            if (OpMode == OperationsMode.ConstantCurrent)
            {
                return InputValue;
            }
            else
            {
                return 0; //Set MinCurrent To GetFirstVoltageValue
            }
        }
        private double CalcSetValue()
        {
            if (OpMode == OperationsMode.ConstantVoltage)
            {
                if (LastMVoltage != SetValue)
                {
                    return Convert.ToDouble(SetValue / LastResistance);
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
                if (SetValue != (LastMVoltage/1000 * LastMAmpere ))
                {
                    double val = Convert.ToInt32(SetValue / (LastMVoltage / 1000)*1000);
                    return Convert.ToDouble(SetValue / (LastMVoltage/1000)*1000);
                }
            }
            return -1;
            
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
