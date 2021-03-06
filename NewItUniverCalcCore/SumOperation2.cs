﻿using ItUniverCalcCore.Interfaces;
using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class SumOperation2  : Interfaces.IOperation
    {
        public int argCount => 2;

        public string Name => "Sum2";

        public double Exec(double[] args)
        {
            return args.Aggregate((x,y)=>x+y);
        }
    }
}
