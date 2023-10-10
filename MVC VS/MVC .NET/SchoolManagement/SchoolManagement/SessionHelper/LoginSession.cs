using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManagement.SessionHelper
{
    public class LoginSession
    {
        public static string Email{
            get{
                return HttpContext.Current.Session["Email"] == null ? "" : (string)HttpContext.Current.Session["Email"];
            }
            set{
                HttpContext.Current.Session["Email"] = value;
            }
       }
    }
}