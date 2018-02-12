using ItUniverCalcCore.Interfaces;
using System.Linq;

namespace ItUniverCalcCore.Operations
{
    public class SumOperation : SuperOperation
    {
        public override string Owner => "IT Univer Co.";

        public override string Description => "Арифметическое действие, посредством которого из двух или нескольких чисел получают новое, содержащее столько единиц, сколько было во всех данных числах вместе.";

        public override int argCount => 2;

        public override string Name => "Sum";

        public override double Exec(double[] args)
        {
            return args.Sum();
        }
    }
}
