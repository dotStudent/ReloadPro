using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReloadClient
{
    static class ReloadSerial
    {
        public static int Baudrate { get; set; } = 115200;
        private static string version = "version ";

        public static string[] SerialPorts { get { return ReloadSerial.GetPorts(); } }
        public static string SetPort { get; internal set; } = "";
        public static string GetVersion { get; internal set; }

        //private static SerialPort ComPort;

        public static void ReadVersion()
        {
            try
            {
                foreach (string port in SerialPorts)
                {
                    SerialPort sp = new SerialPort(port, Baudrate);
                    sp.Open();
                    sp.Write("version" + "\r\n");

                    Thread.Sleep(250);  // give it some time to respond
                    //string vers = sp.ReadLine();
                    string vers = sp.ReadExisting().Replace("\r\n", "");
                    if (vers.StartsWith(version))
                    {
                        SetPort = port;
                        GetVersion = vers.Replace(version,"");
                    }
                    sp.Close();
                }
            }
            catch
            {

            }
        }
        private static string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }


    }
}
