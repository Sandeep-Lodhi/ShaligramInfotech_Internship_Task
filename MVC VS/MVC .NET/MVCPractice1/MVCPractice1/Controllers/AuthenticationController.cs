using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModels;
using DatabaseConnection;

namespace MVCPractice1.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        KrunalDhote351Entities db = new KrunalDhote351Entities();
        AuthOperationRepo repo=null;
        public AuthenticationController()
        {
            repo = new AuthOperationRepo();
        }

        public ActionResult Index(string userName) {
            ViewBag.username = userName;
            ViewBag.img = "/Content/Theme/img/KrunalDhote.png";
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.username = "Anonymous User";
            ViewBag.img = "/Content/Theme/img/user.jpeg";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid) { 
                var result = repo.LoggedIn(login);  
                if (result)
                {
                    ModelState.AddModelError("username", "username is not found");

                    return RedirectToAction("Index",new { username=login.username });
                }
            }
            ViewBag.username = "Anonymous User";
            ViewBag.img = "/Content/Theme/img/user.jpeg";
            return View();
        }



        public ActionResult CreateAccount()
        {
            ViewBag.country = new SelectList(db.Countries.ToList(), "id", "countryName");
            ViewBag.username = "Anonymous User";
            ViewBag.img = "/Content/Theme/img/user.jpeg";
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(CreateAccount ca)
        {
            ViewBag.country = new SelectList(db.Countries.ToList(), "id", "countryName");
            if (ModelState.IsValid && ca.password==ca.repeatpassword)
            {
                var result = repo.Create(ca);
                if(result != null)
                {
                    return RedirectToAction("Login");
                }
            }
            return View("CreateAccount");
        }


        public ActionResult ShowTable()
        {
            var result = repo.ShowAllUsers();
            return View(result);
        }

        public ActionResult EditUser(int id)
        {
            ViewBag.country = new SelectList(db.Countries.ToList(), "id", "countryName");
            var result = repo.EditUserDetail(id);
            return View(result);
        }

    }
}