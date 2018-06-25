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
        public bool Stopped { get; private set; } = true;
        public OperationsMode OpMode { get; set; }
        public int InputValue { get; set; }
        public int ShutdownVoltageMV { get; set; }
        public Decimal CumulatedMAh { get; set; }
        public Decimal CumulatedAh { get { return Math.Round(CumulatedMAh / 1000, 2); } }
        public Decimal CumulatedmWh { get; set; }
        public Decimal CumulatedWh { get { return Math.Round(CumulatedWh / 1000, 2); } }

        public Queue<ReloadReceiveData> ReadMessageQueue;
        public Queue<ReloadSendData> WriteMessageQueue;

        public SerialPort ComPort;

        private decimal LastMVoltage;
        private decimal LastMAmpere;

        private bool firstRun = true;


        public void Start()
        {
            if (SerialPorts.Contains(SetPort))
            {
                ComPort.PortName = SetPort;
                ComPort.BaudRate = Baudrate;
                ComPort.Open();
                ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);

                ComPort.WriteLine("set " + CalcFirstInputValue());
                firstRun = false;

                ComPort.WriteLine("monitor " + SetInterval);

            }
        }
        public void Stop()
        {
            ComPort.WriteLine("set " + "0");
        }
        void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReloadReceiveData rd = new ReloadReceiveData(ComPort.ReadLine());
            ReadMessageQueue.Enqueue(rd);
            LastMAmpere = rd.CurrentMA;
            LastMVoltage = rd.VoltageMV;
            if (ShutdownVoltageMV >= LastMVoltage)
            {
                Stop();
            }
            // Call here CalcSetValue for new SetValue
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

        }

    }
}
