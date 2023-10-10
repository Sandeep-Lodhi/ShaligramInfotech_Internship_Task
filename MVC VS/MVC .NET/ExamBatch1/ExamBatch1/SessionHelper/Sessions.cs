using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamBatch1.SessionHelper
{
    public class Sessions
    {
        public static string username
        {
            get {
                return HttpContext.Current.Session["Username"] == null ? "" : (string)HttpContext.Current.Session["Username"];           
            }
            set
            {
                HttpContext.Current.Session["Username"] = value;
            }
        }
    }
}