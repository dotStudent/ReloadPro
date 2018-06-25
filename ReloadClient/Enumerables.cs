using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadClient
{
    enum OperationsMode
    {
        ConstantCurrent,
        ConstantVoltage,
        ConstantResistance,
        ConstantPower
    };
    enum MsgType
    {
        Error,
        Read,
        Set,
        Unknown
    };
}
