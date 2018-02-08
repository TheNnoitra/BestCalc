using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class DivOperation : Interfaces.IOperation
    {
        public int argCount => 2;

        public string Name => "Div";

        public double Exec(double[] args)
        {
            return args.Aggregate((x,y)=>x/y);
        }
    }
}
