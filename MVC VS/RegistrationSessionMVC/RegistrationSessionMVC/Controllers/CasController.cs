using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
namespace RegistrationSessionMVC.Controllers
{
    public class CasController : Controller
    {
        // GET: Cas
        public ActionResult Index()
        {
            SandeepMVCEntities sd = new SandeepMVCEntities();
            ViewBag.CountryList = new SelectList(GetCounttryList(), "Cid", "Cname");

            return View();
        }

        public List<country> GetCounttryList()
        {
            SandeepMVCEntities sd = new SandeepMVCEntities();
            List<country> countries = sd.countries.ToList();
            return countries;
        }

        public ActionResult GetStateList(int Cid)
        {
            SandeepMVCEntities sd = new SandeepMVCEntities();
            List<State> selectList = sd.States.Where(x => x.Cid == Cid).ToList();
            ViewBag.Slist = new SelectList(selectList, "Sid", "Sname");
            return PartialView("DisplayStates");
        }

        public ActionResult GetCityList(int Sid)
        {
            SandeepMVCEntities sd = new SandeepMVCEntities();
            List<City> selectList = sd.Cities.Where(x => x.Sid == Sid).ToList();
            ViewBag.Citylist = new SelectList(selectList, "Cityid", "Cityname");
            return PartialView("DisplayCities");
        }
    }
}