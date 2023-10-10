using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.AuthFilter
{
    public class Authentication: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            if (HttpContext.Current.Session["UserEmail"] == null)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}