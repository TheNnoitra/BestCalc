using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class MulUperation : Interfaces.IOperation
    {
        public int argCount => 2;

        public string Name => "Mul";

        public double Exec(double[] args)
        {
            return args.Aggregate((x,y)=>x*y);
        }
    }
}
