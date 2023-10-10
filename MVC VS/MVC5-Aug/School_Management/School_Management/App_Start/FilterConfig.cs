using System.Web;
using System.Web.Mvc;

namespace School_Management
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
  
    public class LoginAction : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["Email"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Signup");
            }
        }
    }
}
