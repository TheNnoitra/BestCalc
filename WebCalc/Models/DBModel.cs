using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebCalc.Models
{
    public class DBModel
    {
       public IEnumerable<string> Operation { get; set; }

       public string Args { get; set; }

       public double? Result { get; set; }

       public  DateTime ExecDate { get; set; }

       public string UserName { get; set; }
    }
}