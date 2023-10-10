using DatabaseConnection;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice1.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        KrunalDhote351Entities db = new KrunalDhote351Entities();
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetState(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<State> state = db.States.Where(x => x.CountryId == id).ToList();
            return Json(state,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetCity(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<City> city = db.Cities.Where(x => x.StateId == id).ToList();
            return Json(city,JsonRequestBehavior.AllowGet);
        }


    }
}