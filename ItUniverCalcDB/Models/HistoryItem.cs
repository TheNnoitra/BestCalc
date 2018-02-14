using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniverCalcDB.Models
{
    public class HistoryItem : IHistoryItem
    {
        public long Id { get; set; }

        public string Operation { get; set; }

        public string Args { get; set; }

        public double? Result { get; set; }

        public DateTime ExecDate { get; set; }

        public string UserName { get; set; }
    }
}
