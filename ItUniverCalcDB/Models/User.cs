using ItUniverCalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItUniverCalcDB.Models
{
    public class User: IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
