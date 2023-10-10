using SanjayTest.Model.Context;
using SanjayTest.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjayTest.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        IAuthInterface authInterface;
        public AuthController(IAuthInterface authInterface)
        {
            this.authInterface = authInterface;
        }
        // GET: Auth

        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string UserPassword)
        {
            ViewBag.error = "";
            int success = authInterface.UserLogin(UserName, UserPassword);
            if (success == 0)
            {
                ViewBag.error = "You have not registered yet! please register";
            }
            else if (success == 2)
            {
                ViewBag.error = "Wrong Password!";
            }
            else if (success == 1)
            {
                ViewBag.error = "Login Success!";
                User LogUser = authInterface.GetLoggedUser(UserName);
                Session["UserId"] = LogUser.UserId;
                Session["UserName"] = LogUser.UserName;
                return RedirectToAction("StartQuiz", "Home");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}