using MVC_CRUD_Sandeep.Models.DbContext;
using MVC_CRUD_Sandeep.Models.Models;
using MVC_CRUD_Sandeep.Repository.Intreface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_CRUD_Sandeep.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        IAuth _Auth;
        public AuthController(IAuth auth)
        {
            _Auth = auth;
        }

        SandeepTestDBEntities db = new SandeepTestDBEntities();
        // GET: Users



        //[Authorize]
        public ActionResult Index()
        {

            return View(db.User.ToList());
        }
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserModel userModel)
        {
            using (SandeepTestDBEntities db = new SandeepTestDBEntities())
            {
                //FormsAuthentication.HashPasswordForStoringInConfigFile(userModel.UserPassword, FormsAuthPasswordFormat.SHA1);
                var obj = db.User.Where(u => u.UserId.Equals(userModel.UserId)).FirstOrDefault();
                if (obj == null)
                {
                   
                        _Auth.SignUp(userModel);
                        return RedirectToAction("Login");
                   
                   
                }
                else
                {
                    ModelState.AddModelError("", "User exists ,Please login with your password");
                }
                return View(userModel);
            }

        }
        public ActionResult Login()
        {
            
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel userModel)
        {
            var checkLogin = db.User.Where(x => x.UserEmail.Equals(userModel.UserEmail) && x.UserPassword.Equals(userModel.UserPassword)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["id"] = userModel.UserId.ToString();
                Session["Name"] = "Hello ! Welcome " + checkLogin.UserName;
                TempData["success"] = "Login SuccessFul";


                return RedirectToAction("Index", "Auth", new { id = checkLogin.UserId });
            }
            else
            {
                ViewBag.Notification = "Wrong Username of password";

            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }


    }
}