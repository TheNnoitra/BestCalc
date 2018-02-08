using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class MinOperation : Interfaces.IOperation
    {
        public int argCount => 2;

        public string Name => "Min";

        public double Exec(double[] args)
        {
            return args.Aggregate((x, y) => x - y);
        }
    }
}
