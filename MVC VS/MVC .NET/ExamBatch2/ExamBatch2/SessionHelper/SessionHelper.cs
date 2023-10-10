using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamBatch2.SessionHelper
{
    public class SessionHelper
    {
        public static string Username
        {
            get 
            {
                return HttpContext.Current.Session["UserName"] == null ? "" : (string)HttpContext.Current.Session["UserName"];
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
    }
}