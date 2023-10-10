using SandeepMVC3_Test.Models.DbContext;
using SandeepMVC3_Test.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandeepMVC3_Test.Controllers
{
    public class HomeController : Controller
    {
        IAuth _Auth;

        public HomeController(IAuth auth)
        {
            _Auth = auth;
        }



        public ActionResult index()
        {
            SandeepTestDBEntities db = new SandeepTestDBEntities();


            return View(_Auth.index());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}