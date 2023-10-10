using CRUDusingAJAX.Models.Models;
using CRUDusingAJAX.Repository.Interfaces;
using CRUDusingAJAX.SessionHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingAJAX.Controllers
{
    public class HomeController : Controller
    {

        ICRUDusingAJAX _Icrud;
        public HomeController(ICRUDusingAJAX Icrud)
        {
            _Icrud = Icrud;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register(RegisterModel data)
        {
            return View(data);
        }
        
        [HttpPost]
        public JsonResult RegisterUser(RegisterModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _Icrud.RegisterService(data);
                    if (result > 0)
                    {
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Login(LoginModel data)
        {
            return View(data);
        }

        public JsonResult LoginUser(LoginModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result= _Icrud.LoginService(data);
                    Session["username"] = data.email;
                    Sessions.username=data.email;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetUser()
        {
            try
            {
                var result= _Icrud.GetUsers();
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult EditUser(int id)
        {
            try
            {
                var result= _Icrud.GetUserById(id);
                return View("Register",result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}