﻿using System;
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
        StreamWriter log;

        public void toFile(double current, double voltage, double resistance, double power, double cumPower, double cumCurrent)
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
                log.Write(DateTime.Now.ToString());
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
                log.Write(";");
                log.WriteLine();
                log.Close();
            }
            catch (Exception exp)
            {
                throw new System.Exception(exp.ToString());
            }
        }
        private void PrepareFile(string path, string file)
        {
            try
            {
                firstrun = false;
                log = new StreamWriter(path + file);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    if (File.Exists(path + file) && Append == false)
                    {
                        File.Delete(path + file);
                    }
                    if (File.Exists(path + file) == false)
                    {
                        log = File.AppendText(path + file);
                        log.Write("DateTime;Current;Voltage;Resistance;Power;CumPower;CumMah");
                        log.WriteLine();
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
