using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDusingAJAX.SessionHelpers
{
    public class Sessions
    {
        public static string username
        {
            get
            {
                return HttpContext.Current.Session["username"] == null ? "" : (string)HttpContext.Current.Session["username"];
            }
            set
            {
                HttpContext.Current.Session["username"] = value;
            }
        }
    }
}