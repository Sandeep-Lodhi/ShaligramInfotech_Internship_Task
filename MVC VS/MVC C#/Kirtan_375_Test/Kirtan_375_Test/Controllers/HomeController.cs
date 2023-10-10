using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models.Model;
using Test.Repository.Repository;

namespace Kirtan_375_Test.Controllers
{
    public class HomeController : Controller
    {
        public ILogin loginuser;

        public HomeController(ILogin _login)
        {
            loginuser = _login;
        }
        public ActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(LoginModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = loginuser.GetUserDetail(user);
                    if (result != null)
                    {
                        Session["IsLoggedIn"] = result.id;
                        return Redirect("../Dash/Order");
                    }
                    else
                    {
                        return View("LoginUser");
                    }
                }
                return View("LoginUser");
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
