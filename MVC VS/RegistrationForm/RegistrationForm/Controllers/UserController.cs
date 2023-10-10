using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RegistrationForm.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            sandeep_Phase3 sandeep_Phase3 = new sandeep_Phase3();

            return View(sandeep_Phase3.User.ToList());
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User userModel = new User();
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using(sandeep_Phase3 sandeep_Phase3 = new sandeep_Phase3())
            {
                if(sandeep_Phase3.User.Any(x=> x.UserName == userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exixt.";
                    return View("AddOrEdit", userModel);

                }
                sandeep_Phase3.User.Add(userModel);
                sandeep_Phase3.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMassage = "Registration Sucessful !";
            return View("AddOrEdit", new User());
        }
    }
}