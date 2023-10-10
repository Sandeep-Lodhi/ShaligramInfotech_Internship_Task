using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandeep_Bootstrappractice.ActionFilter
{
    public class Authentication : ActionFilterAttribute
    {


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

 
        }
 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Name"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }

        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }
        
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }
    }
}