using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class SumOperation : Interfaces.IOperation
    {
        public int argCount => 2;

        public string Name => "Sum";

        public double Exec(double[] args)
        {
            return args.Aggregate((x,y)=>x+y);
        }
    }
}
