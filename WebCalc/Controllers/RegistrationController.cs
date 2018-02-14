using ItUniverCalcDB.Models;
using ItUniverCalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private IUserRepository Users { get; set; }

        public RegistrationController()
        {
            Users = new UserRepository();
        }
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            var valid = false;
            if (model.Password == model.SecondPassword)
            {
                var uss = new User();

                uss.Name = model.Name;
                uss.Login = model.Login;
                uss.Password = model.Password;

                if (model.Sex == false)
                { uss.Sex = "Female"; }
                else
                { uss.Sex = "Male"; }

                uss.BirthDay = model.BirthDay.Date;

                Users.Save(uss);

                valid = true;
            }
            ModelState.AddModelError("", "Не удалось выполнить регистрацию");

            if (valid != false)
            { FormsAuthentication.RedirectToLoginPage(); }

            return View(model);
        }
    }
}