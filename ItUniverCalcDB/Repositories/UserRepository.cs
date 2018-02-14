using ItUniverCalcDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniverCalcDB.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
         string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\Users\Asus_PC\Documents\Visual Studio 2015\Projects\ELMA\BestCalc\ItUniverCalcDB\App_Data\CalcDB.mdf;
                                            Integrated Security = True";
         string tableName2 { get; set; }

        public bool Check(string login, string password)
        {
            //todo: переделать!!!
            return GetAll().Any(u => u.Login == login && u.Password == password);
        }

        public User GetByName(string login)
        {
            throw new NotImplementedException();
        }

        public void Saver(User item)
        {
            var props = typeof(User).GetProperties()
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

                // todo boolean

                values.Add(str);
            }

            var strColumns = "[" + string.Join("], [", columns) + "]";
            var strValues = string.Join(", ", values);

            var insertQuery =
                $"INSERT INTO [dbo].[User] ({strColumns}) VALUES ({strValues})";


            string queryString = item.Id > 0
                ? "UPDATE * FROM [dbo].[User]"
                : insertQuery;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                var count = command.ExecuteNonQuery();
            }
        }
    }
}
