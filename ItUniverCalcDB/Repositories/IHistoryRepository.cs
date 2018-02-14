using ItUniverCalcDB.Models;
using System.Collections;
using System.Collections.Generic;

namespace ItUniverCalcDB.Repositories
{
    public interface IHistoryRepository : IBaseRepository<HistoryItem>
    {
    }

    public interface IOperationRepository : IBaseRepository<Operation>
    {
    }
}
