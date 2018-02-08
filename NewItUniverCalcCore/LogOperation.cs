using ItUniverCalcCore.Interfaces;
using System;
using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class LogOperation  : Interfaces.IOperation
    {
        public int argCount => 2;

        public string Name => "Log";

        public double Exec(double[] args)
        {
            return args.Aggregate((x,y)=>Math.Log(x, y));
        }
    }
}
