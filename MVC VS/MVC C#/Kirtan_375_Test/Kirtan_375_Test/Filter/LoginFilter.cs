using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Test.Models.DbContext;

namespace Kirtan_375_Test.Filter
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["IsLoggedIn"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/LoginUser");
            }
            else
            {
                return;
            }
        }
    }
}