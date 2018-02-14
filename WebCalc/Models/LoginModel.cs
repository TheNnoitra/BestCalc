using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCalc.Models
{
    public class LoginModel
    {

        [Display(Name = "Пользователь")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}