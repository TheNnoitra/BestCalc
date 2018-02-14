using ItUniverCalcDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniverCalcDB.Repositories
{
    public class HistoryRepository : BaseRepository<HistoryItem>, IHistoryRepository
    {
        public HistoryRepository() : base("History")
        {

        }
    }
}

