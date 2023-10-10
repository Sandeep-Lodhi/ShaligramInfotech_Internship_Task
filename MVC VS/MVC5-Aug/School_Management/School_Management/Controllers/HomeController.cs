using School_Management.Helpers.UserHelper;
using School_Management.Models;
using School_Management.Models.Context;
using School_Management.Models.Model;
using School_Management.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Management.Controllers
{   
    public class HomeController : Controller
    {
        public IUserInterface Iuser;

        public HomeController(IUserInterface _IUser)
        {
            Iuser = _IUser;
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(CustomUserPanel data1)
        {
            if (Iuser.SignUp(data1) == true)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.error = "This Email Already exists";
                return View();
            }

        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(CustomUserPanel data2)
        {
            //int Login = Iuser.Login(data2);
            //if (Login==1)
            //{
            //    return RedirectToAction("DashBoard", "Home");
            //}
            //if(Login==2)
            //{
            //    ViewBag.error = "Email Invalid";
            //    return View();
            //}
            //if (Login == 3)
            //{
            //    ViewBag.error = "Password Invalid";
            //    return View();
            //}
            //return View();

            string Login = Iuser.Login(data2);

            if (Login == "Invalid Email" || Login == "Invalid Password" || Login == "Invalid Email & password")
            {
                TempData["Error"] = Login;
                return View();
            }
            else
            {
                Session["Email"] = Login;
                return RedirectToAction("DashBoard", "Home");
            }

        }

        //[LoginAction]
        public ActionResult DashBoard()
        {
            List<CustomUserPanel> customuser = new List<CustomUserPanel>();
            customuser = Iuser.GetAllUserList();
                return View(customuser);
        }
        public ActionResult DeleteUserRecord(int id)
        {
            try
            {
                Iuser.DeleteUserRecord(id);
                return RedirectToAction("DashBoard", "Home");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult EditUserRecord(int id)
        {
            var Edit = Iuser.EditUserRecord(id);
            return View(Edit);
        }
        [HttpPost]
        public ActionResult EditUserRecord(CustomUserPanel customUserPanel)
        {
            //if (ModelState.IsValid)
            //{
            Iuser.UpdateUserData(customUserPanel);
            //Iuser.Save();



            return RedirectToAction("DashBoard");
            //}
            //else
            //{
            //return View();
            //}



        }

        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Login");
            }
            catch (System.Exception)
            {
                throw;
            }
            return View();
        }

    }
}