using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Models
{
    public class OperationModel
    {

        public OperationModel()
        {

        }

        [Display(Name = "Операция")]
        [Required]
        public string Operation { get; set; }

        [Display(Name = "Аргументы")]
        public IEnumerable<double> Args { get; set; }

        [Display(Name = "Результат")]
        [ReadOnly(true)]
        public double? Result { get; set; }

        public IEnumerable<SelectListItem> Operations { get; set; }

    }
}