using RoleBased.Model;
using RoleBased.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Membership = RoleBased.Model.Membership;

namespace RoleBased.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Membership model)
        {
            using (var Context = new Sit375_SandeepDBEntities())
            {
                bool isValid = Context.Users.Any(x => x.Name == model.Name && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    return RedirectToAction("Index", "Employees");
                }
               
                    ModelState.AddModelError("", "Invalid username And Password !");
                    return View();
                
            }
            
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Users user)
        {
            using( var Context = new Sit375_SandeepDBEntities())
            {
              
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            return RedirectToAction("Login");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}