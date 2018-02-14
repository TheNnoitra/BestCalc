using BestCalc;
using ItUniverCalcDB.Models;
using ItUniverCalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        DBRepository rep = new DBRepository();
        private IHistoryRepository HistoryRepository = new HistoryRepository();

        private IOperationRepository OperationRepository = new OperationRepository();

        private IUserRepository Users { get; set; }
        // GET: Calc
        public ActionResult Index()
        {
            var calc = new Calc();
            var model = new OperationModel();

            model.Operations = calc.GetOpers().Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}" });

            return View(model);
        }


        [HttpPost]
        public ActionResult Index(OperationModel model)
        {
            var calc = new Calc();
            model.Operations = calc.GetOpers().Select(o => new SelectListItem() { Text = $"{o.Name}", Value = $"{o.Name}" });
            model.Result = calc.Exec(model.Operation, model.Args.ToArray());

            var uss = new HistoryItem();
            uss.Operation = model.Operation;
            uss.Args = string.Join(" ", model.Args);
            uss.Result = model.Result;
            uss.ExecDate = DateTime.Now;
            uss.UserName = this.User.Identity.Name;
            HistoryRepository.Save(uss);

            return View(model);
        }

        public ActionResult History()
        {
            var sorted = ReadData();

            return View(sorted);
        }

        private IEnumerable<HistoryItem> ReadData()
        {
            var items = new List<HistoryItem>();

            var history = HistoryRepository.GetAll();
            foreach (var item in history)
            {
                if (item.UserName == this.User.Identity.Name)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        }
}