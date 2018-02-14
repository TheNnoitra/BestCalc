using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebCalc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //регистрирует все области видимости
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //шаблон маршрута
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //склейка JS файлов
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
