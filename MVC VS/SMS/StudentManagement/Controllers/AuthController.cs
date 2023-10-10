using Newtonsoft.Json;
using StudentManagement.Models;
using StudentManagement.Models.Models;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManagement.Controllers
{

    public class AuthController : Controller
    {
        // GET: Auth
        IAuthInterface authInterface;
        IUserRoleInterface userRoleInterface;
        IUserInterface userInterface;
        public AuthController(IAuthInterface authInterface, IUserRoleInterface userRoleInterface, IUserInterface userInterface)
        {
            this.authInterface = authInterface;
            this.userRoleInterface = userRoleInterface;
            this.userInterface = userInterface;
        }

        public ActionResult Login()
        {
            try
            {
                ViewBag.UserRoles = authInterface.GetAllRole();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            try
            {
                ViewBag.UserRoles = authInterface.GetAllRole();

                int loginChkInt = authInterface.UserLogin(user);

                switch (loginChkInt)
                {
                    case 0:
                        ViewBag.error = "Email Does Not Exist! Please Redister First";
                        break;
                    case 1:
                        ViewBag.error = "Login Success";
                        var logUser = userInterface.GetLoggedUserDetailByEmail(user.UserEmail);
                        Session["UserEmail"] = logUser.UserEmail;
                        Session["UserName"] = logUser.UserName;
                        return RedirectToAction("Home", "Dashboard");
                    case 2:
                        ViewBag.error = "Role Does Not Assigned";
                        break;
                    case 3:
                        ViewBag.error = "Incorrect password";
                        break;
                    default:
                        ViewBag.error = "Login Failed";
                        break;
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult SignUp()
        {
            try
            {
                ViewBag.UserRoles = authInterface.GetAllRole();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult SignUp(UserModel userModel)
        {
            try
            {
                int userId = authInterface.CreateNewUser(userModel);

                if (userId != 0)
                {
                    foreach (int roleId in userModel.UserRoleId)
                    {
                        userRoleInterface.CreateUserRole(userId, roleId);
                    }
                    return RedirectToAction("Home", "Dashboard");
                }
                else
                {
                    ViewBag.UserRoles = authInterface.GetAllRole();
                    ViewBag.error = "You have already registered! Please Login";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Auth");
        }
    }
}