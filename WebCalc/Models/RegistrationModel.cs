using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class RegistrationModel
    {
        [Display(Name = "Имя пользователя")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Логин")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Повторите пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string SecondPassword { get; set; }

        [Display(Name = "Пол")]
        public Boolean Sex { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }
    }
}