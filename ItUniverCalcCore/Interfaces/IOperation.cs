using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniverCalcCore.Interfaces
{
    public interface IOperation
    {
        int argCount { get; }
        double Exec(double[] args);
        string Name { get; }
    }
}
