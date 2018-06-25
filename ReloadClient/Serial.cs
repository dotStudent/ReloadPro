using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadClient
{
    class Serial
    {
        public static string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
