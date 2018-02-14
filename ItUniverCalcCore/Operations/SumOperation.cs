using ItUniverCalcCore.Interfaces;
using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class SumOperation : Interfaces.IOperation
    {
        public int argCount => 2;

        public string Name => "Mul";

        public double Exec(double[] args)
        {
            return args.Sum();
        }
    }
}
