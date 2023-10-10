using School_Management.Models.Model;
using School_Management.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Management.Controllers
{
    public class CityController : Controller
    {
        ICityInterface Icity;
        public CityController(ICityInterface _Icity)
        {
            Icity = _Icity;
        }
        // GET: City
        public ActionResult AddCity()
        {
            ViewBag.statelist = new SelectList(Icity.StateList(), "StateId", "StateName");

            ViewBag.countrylist = new SelectList(Icity.CountryList(), "CountryId", "CountryName");

            return View();
        }
        [HttpPost]
        public ActionResult AddCity(CityCustomModel customcity)
        {
            ViewBag.statelist = new SelectList(Icity.StateList(), "StateId", "StateName");
            ViewBag.countrylist = new SelectList(Icity.CountryList(), "CountryId", "CountryName");

            string city = Icity.AddCity(customcity);
            if (city == "pass")
            {
                return RedirectToAction("DisplayCity", "City");
            }
            else
            {
                ViewBag.error = "City Already exist in data";
                return View();
            }
        }
        public ActionResult DisplayCity()
        {
            var CityList = Icity.GetCitylist();
            return View(CityList);
        }

        public ActionResult EditCity(int id)
        {
            ViewBag.statelist = new SelectList(Icity.StateList(), "StateId", "StateName");
            ViewBag.countrylist = new SelectList(Icity.CountryList(), "CountryId", "CountryName");
            CityCustomModel city = Icity.GetCity(id);
            return View(city);
        }
        [HttpPost]
        public ActionResult EditCity(CityCustomModel customcity)
        {
            ViewBag.statelist = new SelectList(Icity.StateList(), "StateId", "StateName");
            ViewBag.countrylist = new SelectList(Icity.CountryList(), "CountryId", "CountryName");

            string city = Icity.EditCity(customcity);
            if (city == "pass")
            {
                return RedirectToAction("DisplayCity", "City");
            }
            else
            {
                ViewBag.error = "City Already exist in data";
                return View();
            }
        }
        public ActionResult DeleteCityRecord(int id)
        {
            try
            {
                Icity.DeleteCityRecord(id);
                return RedirectToAction("DisplayCity", "City");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    
        //public JsonResult GetCityAjax(string city)
        //{
            
        //    return Json("",JsonRequestBehavior.AllowGet);
        //}
    }
}