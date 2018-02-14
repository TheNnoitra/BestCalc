using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc
{
    public static class Helper
    {
        public static MvcHtmlString Random(this HtmlHelper html, int start, int finish)
        {
            var rand = new Random().Next(start, finish);
            var button = $"<input type=\"button\" value=\"{rand}\" class=\"btn\">";
            return MvcHtmlString.Create(button);
        }

        public static MvcHtmlString Random1(this HtmlHelper html, int start, int finish)
        {
            var rand = new Random().Next(start, finish);

            var button = new TagBuilder("input");
            button.AddCssClass("btn");
            button.Attributes["type"] = "button";
            button.MergeAttribute("value", $"{rand}"); 

            return MvcHtmlString.Create(button.ToString());
        }
    }
}