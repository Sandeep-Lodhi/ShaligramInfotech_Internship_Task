using OrderPlaceTest.Models.DbContext;
using OrderPlaceTest.Models.Models;
using OrderPlaceTest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OrderPlaceTest.Controllers
{
    public class AuthController : Controller
    {
         IAuthentication _IAuth;

        public AuthController(IAuthentication IAuth)
        {
            _IAuth = IAuth;
        }

        Sit375DBEntities db = new Sit375DBEntities();

        // GET: Auth
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        public ActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Signup(UserModel user)
        {

            if (db.User.Any(x => x.Email == user.Email))
            {
                ViewBag.Notification = "This is account has aleady existed";
                return View();
            }
            else
            {
                _IAuth.Signup(user);
                Session["Id"] = user.id.ToString();
                Session["Name"] = user.Name.ToString();
                return RedirectToAction("Login", "Auth");
            }
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            var checkLogin = db.User.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
            if (checkLogin != null)
            {

                //FormsAuthentication.SetAuthCookie(user.Name, false);
                Session["id"] = user.id.ToString();
                Session["Name"] = user.Email;
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                ViewBag.Notification = "Wrong Username of password";

            }
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return  RedirectToAction("Login", "Auth");
        }

        public ActionResult Details(int? id)
        {
            var data = db.User.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int? id)
        {
            var data = db.User.Where(x => x.id == id).FirstOrDefault();
            db.User.Remove(data);
            db.SaveChanges();
           return  RedirectToAction("Index", "Auth");
        }

    }
}