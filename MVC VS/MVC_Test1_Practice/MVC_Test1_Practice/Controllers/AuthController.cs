using MVC_Test1_Practice.Model.DbContext;
using MVC_Test1_Practice.Model.Models;
using MVC_Test1_Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test1_Practice.Controllers
{
    public class AuthController : Controller
    {
        IAuthInterface authInterface;
        public AuthController(IAuthInterface authInterface)
        {
            this.authInterface = authInterface;
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel userModel)
        {
            ViewBag.error = "";
            int success = authInterface.UserSignUp(userModel);
            if(success == 0)
            {
                ViewBag.error = "Email Already in use! Please enter another";
                return View();
            }
            return RedirectToAction("Login");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserEmail, string UserPassword)
        {
            ViewBag.error = "";
            int success = authInterface.UserLogin(UserEmail, UserPassword);
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
                User LogUser = authInterface.GetLoggedUser(UserEmail);
                Session["UserId"] = LogUser.UserId;
                Session["UserName"] = LogUser.UserName;
                Session["UserEmail"] = UserEmail;
                return RedirectToAction("CreateOrder", "Home");
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