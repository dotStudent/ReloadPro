using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadClient
{
    static class InputLimits
    {
        //Interval ms
        const int minTime = 1000;
        const int maxTime = 60000;
        
        //Current mA
        const int maxCurrent = 6000;

        //Voltage v
        const int maxVoltage = 60;

        //Resistance Ohm
        const int minResistance = 1000;

        //Power W
        const int maxPower = 25;

        static int TimeLimit(int value)
        {
            if (value > maxTime)
            {
                return maxTime;
            }
            else if (value < minTime)
            {
                return minTime;
            }
            else
            {
                return value;
            }
        }
        static int CurrentLimit(int value)
        {
            if (value > maxCurrent)
            {
                return maxCurrent;
            }
            else
            {
                return value;
            }
        }
        static int VoltageLimit(int value)
        {
            if (value > maxVoltage)
            {
                return maxVoltage;
            }
            else
            {
                return value;
            }
        }
        static int PowerLimit(int value)
        {
            if (value > maxPower)
            {
                return maxPower;
            }
            else
            {
                return value;
            }
        }
    }
}
