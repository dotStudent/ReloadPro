using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReloadClient
{
    class ReloadReceiveData
    {
        public Double VoltageMV { get; private set; }
        public Double VoltageV { get { return Math.Round(VoltageMV / 1000, 2); } }
        public Double CurrentMA { get; private set; }
        public Double CurrentA { get { return Math.Round(CurrentMA / 1000, 2); } }
        public Double Resistance
        {
            get
            {
                if (VoltageMV > 0)
                {
                    return Math.Round(CurrentMA / VoltageMV, 2);
                }
                else
                {
                    return Int32.MaxValue;
                }
            }
        }
        public Double PowerMW
        {
            get
            {
                if (VoltageMV > 0)
                {
                    return Math.Round((VoltageV * CurrentA) * 1000, 2);
                }
                else
                {
                    return 0;
                }
            }
        }
        public Double PowerW { get { return Math.Round(PowerMW / 1000, 2); } }
        public string Error { get; private set; }
        public MsgType MessageType {get; private set; }
        public DateTime TimeStamp { get; private set; }

        public ReloadReceiveData(string input)
        {
            TimeStamp = DateTime.Now;

            if (input.StartsWith("err"))
            {
                MessageType = MsgType.Error;
                Error = input.Remove(0, 4);
            }
            else if (input.StartsWith("set"))
            {
                MessageType = MsgType.Set;
                CurrentMA = Convert.ToDouble(input.Remove(0, 4));
                if (VoltageMV == 0)  //Workaround
                {
                   // VoltageMV = 1;
                }
            }
            else if (input.StartsWith("read"))
            {
                MessageType = MsgType.Read;
                string[] read = Regex.Split(input, " ");
                CurrentMA = Convert.ToDouble(read[1]);
                string voltage = read[2];
                VoltageMV = Convert.ToDouble(voltage.Replace("\r\n", "").Replace("\r", "").Replace("\n", ""));
            }
            else
            {
                MessageType = MsgType.Unknown;
            }
        }
    }
}
