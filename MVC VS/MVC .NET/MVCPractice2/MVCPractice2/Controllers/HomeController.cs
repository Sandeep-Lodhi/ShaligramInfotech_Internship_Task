using Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice2.Controllers
{
    public class HomeController : Controller
    {
        IStudentInterface _Istudent;
        public HomeController(IStudentInterface student)
        {
            _Istudent = student;
        }
        public ActionResult Index()
        {
            var result = _Istudent.GetDetails();
            return View(result);
        }
        public ActionResult Register(int id=0)
        {
            ViewBag.Country = _Istudent.Country();
            ViewBag.Department = _Istudent.Department();
            if (id == 0)
            {
                ViewBag.State = new SelectList("");
                ViewBag.City = new SelectList("");
                return View();
            }
            else
            {
                var result = _Istudent.Edit(id);
                ViewBag.State = _Istudent.State(result.CountryId);
                ViewBag.City = _Istudent.City(result.StateId);
                return View(result);
            }
        }
        public ActionResult Login()
        {
            return View();
        }


        public JsonResult GetState(int id)
        {
            try
            {
                var result = _Istudent.State(id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetCity(int id)
        {
            try { 
                var result = _Istudent.City(id);
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public ActionResult CountryCityState()
        {
            ViewBag.Country = _Istudent.Country();
            ViewBag.State = _Istudent.State(101);
            ViewBag.City = _Istudent.City(127);
            return View();
        }
    }
}