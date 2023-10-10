using Crud_Practice_4.Model.DB.Context;
using Crud_Practice_4.Model.Model;
using Crud_Practice_4.Reposatory.Inserface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Crud_Practice_4.Controllers
{
    public class LoginController : Controller
    {

        public Jatin_dEntities2 db = new Jatin_dEntities2();
        public IUserInterface1 IUser_Interface1;

        public ActionResult Register_page()
        {
            return View();
        }
        public ActionResult Login_result()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login_result(Login_Model _Model)
        {
          if(db.User_login.Any(x=>x.Email==_Model.Email && x.Password == _Model.password)){
                return RedirectToAction("Show", "Login");
            }
            return View(_Model);
        }
        public ActionResult Show()
        {
            ViewBag.Notification = "Login Success!";
            return View();
        }

    }


}