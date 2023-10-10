using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandeepLodhi_ThemeIntegration_Task.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult Error_404Page()
        {
            return View();
        }

        public ActionResult BlankPage()
        {
            return View();
        }
    }
}