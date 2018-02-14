using ItUniverCalcDB.Models;
using ItUniverCalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniverCalcWinFormApp
{
    public static class IHelper
    {
        private static IBaseRepository<HistoryItem> History = new BaseRepository<HistoryItem>("History");



        public static void AddToHistory(string oper, double[] args, double result)
        {
            var item = new HistoryItem();

            item.Args = string.Join(" ", args);
            item.Operation = oper;
            item.Result = result;
            item.ExecDate = DateTime.Now;

            History.Save(item);
        }

        public static string[] GetAll()
        {
            return History.GetAll()
               .Select(hi => $"{hi.Operation}({hi.Args}) = {hi.Result} / {hi.ExecDate}")
               .ToArray();
        }
    }
}
