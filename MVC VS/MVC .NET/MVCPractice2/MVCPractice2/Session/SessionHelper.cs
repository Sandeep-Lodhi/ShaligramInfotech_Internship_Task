using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPractice2.Session
{
    public class SessionHelper
    {
        public static int userId
        {
            get
            {
                return HttpContext.Current.Session["userId"] == null ? 0: (int)HttpContext.Current.Session["userId"];
            }
            set
            {
                HttpContext.Current.Session["userId"] = value;
            }
        }
        public static string userName
        {
            get
            {
                return HttpContext.Current.Session["userName"] == null ? "": (string)HttpContext.Current.Session["userName"];
            }
            set
            {
                HttpContext.Current.Session["userName"] = value;
            }
        }
    }
}