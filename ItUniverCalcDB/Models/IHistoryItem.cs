using ItUniverCalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniverCalcDB.Models
{
    public interface IHistoryItem : IEntity
    {
        string Operation { get; set; }

        string Args { get; set; }

        double? Result { get; set; }

        DateTime ExecDate { get; set; }

        string UserName { get; set; }
    }

}

