using Sandeep_QuizApp_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandeep_QuizApp_Practice.Controllers
{

   

    public class HomeController : Controller
    {

        Sandeep_QuizAppEntities db = new Sandeep_QuizAppEntities();
        public ActionResult Index()
        {
            return View();
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


        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(user _user)
        {
            if (db.users.Any(x => x.Email == _user.Email))
            {
                ViewBag.Notification = "This is account has aleady existed";
                return View();
            }
            else
            {
                db.users.Add(_user);
                db.SaveChanges();

                Session["Id"] = _user.id.ToString();
                Session["Email"] = _user.Email.ToString();
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user _user)
        {
            var data = db.users.Where(x => x.Email.Equals(_user.Email) && x.Password.Equals(_user.Password)).FirstOrDefault();
            if(data != null)
            {
                Session["id"] = _user.id.ToString();
                Session["Email"] = _user.Email.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong email And Password !";
            }
            return View();
        }


      
    }
}