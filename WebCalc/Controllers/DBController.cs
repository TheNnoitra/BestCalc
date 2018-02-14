using ItUniverCalcDB.Models;
using ItUniverCalcDB.Repositories;
using ItUniverCalcWinFormApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    public class DBController : Controller
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                    AttachDbFilename=C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\ItUniverCalcDB\App_Data\CalcDB.mdf;
                                    Integrated Security = True";
        // GET: DB
        public ActionResult History()
        {
            var model = new DBModel();

            model.Operation = RData().Select(i=>i.Operation);

            return View(model);

        }
        private IEnumerable<IHistoryItem> RData()
        {
            var items = new List<IHistoryItem>();

            string queryString = "SELECT * FROM [dbo].[History]";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(ReadSingleRow(reader));
                }
            }

            return items;
        }

        private IHistoryItem ReadSingleRow(IDataRecord record)
        {
            var item = new HistoryItem();

            item.Id = (long)record["Id"];
            item.Operation = (string)record["Operation"];
            item.Args = (string)record["Args"];

            var ind = record.GetOrdinal("Result");
            var isnull = record.IsDBNull(ind);
            if (!isnull)
            {
                item.Result = (double?)record["Result"];
            }

            item.ExecDate = (DateTime)record["ExecDate"];

            return item;
        }
    }
    
}