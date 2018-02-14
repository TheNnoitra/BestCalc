using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItUniverCalcDB.Models;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace ItUniverCalcDB.Repositories
{
    public class DBRepository 
    {
        // todo: вынести в конфиг
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                    AttachDbFilename=C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\ItUniverCalcDB\App_Data\CalcDB.mdf;
                                    Integrated Security = True";

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IHistoryItem Find(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHistoryItem> GetAll()
        {
            return ReadData();
        }

        public void Save(IHistoryItem item)
        {
            var doubleResult = item.Result;
                /*.HasValue
                ? item.Result.Value.ToString(CultureInfo.InvariantCulture)
                : "null";*/


            string queryString = item.Id >= 0
                ? "UPDATE * FROM [dbo].[History]"
                : "INSERT INTO [dbo].[History] ([Operation], [Args], [Result], [ExecDate])" +
                $" VALUES (N'{item.Operation}', N'{item.Args}', {doubleResult}, N'{item.ExecDate}') ";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                var count = command.ExecuteNonQuery();

                connection.Close();
            }
        }

        #region Работа с БД

        private IEnumerable<IHistoryItem> ReadData()
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
            //item.UserName = (string)record["UserName"];

            return item;
        }

        #endregion
    }
}

