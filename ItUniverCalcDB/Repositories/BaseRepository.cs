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
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity
    {
        // todo: вынести в конфиг
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                    AttachDbFilename=C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\ItUniverCalcDB\App_Data\CalcDB.mdf;
                                    Integrated Security=True";
        protected string tableName { get; set; }

        public BaseRepository()
        {
            this.tableName = typeof(T).Name;
        }

         public BaseRepository(string tableName)
        {
            this.tableName = tableName;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public T Find(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return ReadData();
        }

        public void Save(T item)
        {
            var props = typeof(T).GetProperties()
                            .Where(p => p.Name != "Id")
                            .OrderBy(p => p.Name);

            var columns = props.Select(p => p.Name);

            var values = new List<string>();

            foreach (var prop in props)
            {
                var value = prop.GetValue(item);
                var str = $"{value}";

                if (value == null)
                {
                    str = "NULL";
                }
                else if (value is string)
                {
                    str = $"N'{value}'";
                }
                else if (value is DateTime)
                {
                    var date = (DateTime)value;
                    str = $"N'{date.ToString(CultureInfo.InvariantCulture)}'";
                }
                else if (value is double)
                {
                    var doubleValue = (double)value;
                    str = $"{doubleValue.ToString(CultureInfo.InvariantCulture)}";
                }
                // todo boolean

                values.Add(str);
            }

            var strColumns = "[" + string.Join("], [", columns) + "]";
            var strValues = string.Join(", ", values);

            var insertQuery =
                $"INSERT INTO [dbo].[{tableName}] ({strColumns}) VALUES ({strValues})";


            string queryString = item.Id > 0
                ? $"UPDATE * FROM [dbo].[{tableName}]"
                : insertQuery;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var count = command.ExecuteNonQuery();
            }
        }

        #region Работа с БД

        private IEnumerable<T> ReadData()
        {
            var items = new List<T>();

            var queryString = $"SELECT * FROM [dbo].[{tableName}]";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(ReadSingleRow(reader));
                }

                reader.Close();
            }

            return items;
        }

        private T ReadSingleRow(IDataRecord record)
        {
            var obj = Activator.CreateInstance<T>();
            
            var tclass = typeof(T);
            var props = tclass.GetProperties();

            foreach (var prop in props)
            {
                var ind = record.GetOrdinal(prop.Name);
                var isnull = record.IsDBNull(ind);
                if (!isnull)
                {
                    var value = record[prop.Name];

                    prop.SetValue(obj, value);
                }
            }

            return obj;
        }

        #endregion
    }
}
