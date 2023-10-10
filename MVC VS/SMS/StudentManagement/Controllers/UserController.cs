using StudentManagement.AuthFilter;
using StudentManagement.Models;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    [Authentication]
    public class UserController : Controller
    {
        IUserInterface userInterface;

        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        // GET: User
        public ActionResult RetriveUsers()
        {
            try
            {

                List<UserModel> UserModelList = userInterface.GetAllUsers();
                return View(UserModelList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult MyProfile()
        {
            try
            {
                return View(userInterface.GetLoggedUserDetail(User));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}