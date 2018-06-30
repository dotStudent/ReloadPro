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
        public int Baudrate { get; set; } = 115200;
        public string[] SerialPorts { get { return Serial.GetPorts(); } }
        public string SetPort { get; set; }
        public int SetInterval { get; set; }
        public bool Stop { get; set; } = true;
        public bool Stopped { get; private set; } = true;
        public OperationsMode OpMode { get; set; }
        public int InputValue { get; set; }
        public int ShutdownVoltageMV { get; set; }
        public Decimal CumulatedMAh { get; set; }
        public Decimal CumulatedAh { get { return Math.Round(CumulatedMAh / 1000, 2); } }
        public Decimal CumulatedMWh { get; set; }
        public Decimal CumulatedWh { get { return Math.Round(CumulatedMWh / 1000, 2); } }

        public Queue<ReloadReceiveData> ReadMessageQueue;
        public Queue<ReloadSendData> WriteMessageQueue;

        public SerialPort ComPort;
        private int SetValue;
        private int OldInputValue;
        private decimal LastMVoltage;
        private decimal LastMAmpere;
        private decimal LastResistance;
        private bool firstRun = true;


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
                firstRun = false;
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
        void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReloadReceiveData rd = new ReloadReceiveData(ComPort.ReadLine());
            ReadMessageQueue.Enqueue(rd);
            LastMAmpere = rd.CurrentMA;
            LastMVoltage = rd.VoltageMV;
            LastResistance = rd.Resistance;
            CumulatedMWh += rd.PowerMW * (SetInterval / 1000 / 3600);
            CumulatedMAh += rd.CurrentMA * (SetInterval / 1000 / 3600);

            if (rd.MessageType == MsgType.Read)
            {
                if (ShutdownVoltageMV >= LastMVoltage || Stop == true)
                {
                    StopIt();
                }
                if (InputValue != OldInputValue) // Check if user Changed Input Value
                {
                    OldInputValue = InputValue;
                    SetValue = InputValue;
                }
                int newValue = CalcSetValue(); //check next Current Value to Set

                if (newValue != -1)
                {
                    ComPort.WriteLine("set " + newValue);
                }
            }
        }
        public int CalcFirstInputValue()
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
        public int CalcSetValue()
        {
            if (OpMode == OperationsMode.ConstantVoltage)
            {
                if (LastMVoltage != SetValue)
                {
                    return Convert.ToInt32(SetValue / LastResistance);
                }
            }
            else if (OpMode == OperationsMode.ConstantResistance)
            {
                if (LastResistance != SetValue)
                {
                    return Convert.ToInt32(LastMVoltage / SetValue);
                }
            }
            else if (OpMode == OperationsMode.ConstantPower)
            {
                if (SetValue != (LastMVoltage * LastMAmpere ))
                {
                    return Convert.ToInt32(SetValue / LastMVoltage);
                }
            }
            return -1;
            
            //Calc new Value for various Operation Modes
        }

    }
}
