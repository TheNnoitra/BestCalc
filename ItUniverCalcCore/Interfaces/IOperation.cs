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

        string Name { get; }

        double Exec(double[] args);
    }

    public interface ISuperOperation : IOperation
    {
        string Owner { get; }

        string Description { get; }
    }

    public abstract class SuperOperation : ISuperOperation
    {
        public virtual int argCount => 2;

        public virtual string Description => "";

        public virtual string Name => "noname";

        public virtual string Owner => "ITUniver Company";

        public abstract double Exec(double[] args);

        public string OwnerName
        {
            get
            {
                return $"{Owner} / {Name}";
            }
        }
    }
}
