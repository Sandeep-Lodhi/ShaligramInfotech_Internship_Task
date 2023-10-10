using Newtonsoft.Json;
using School_Management.Models.Model;
using School_Management.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Management.Controllers
{
    public class StateController : Controller
    {
        IStateInterface Istate;
        public StateController(IStateInterface _IState)
        {
            Istate = _IState;
        }
        // GET: State
        public ActionResult AddState()
        {
            ViewBag.countrylist = new SelectList(Istate.CountryList(), "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        public ActionResult AddState(StateCustomModel customstate)
        {
            ViewBag.countrylist = new SelectList(Istate.CountryList(), "CountryId", "CountryName");
            string State = Istate.AddState(customstate);
            if (State == "pass")
            {
                return RedirectToAction("DisplayState", "State");
            }
            else
            {
                ViewBag.error = "State Already exist in data";
                return View();
            }
        }
        //public ActionResult DisplayState()
        //{
        //    List<StateCustomModel> StateList = new List<StateCustomModel>();
        //    StateList = Istate.GetStatelist();
        //    return View(StateList);
        //}
        public ActionResult DisplayState()
        {
            var StateList = Istate.GetStatelist();
            return View(StateList);
        }
        public ActionResult EditState(int id)
        {
            ViewBag.countrylist = new SelectList(Istate.CountryList(), "CountryId", "CountryName");
            StateCustomModel state = Istate.GetState(id);
            return View(state);
        }
        [HttpPost]
        public ActionResult EditState(StateCustomModel customstate)
        {
            ViewBag.countrylist = new SelectList(Istate.CountryList(), "CountryId", "CountryName");

            string state = Istate.EditState(customstate);
            if (state == "pass")
            {
                return RedirectToAction("DisplayState", "State");
            }
            else
            {
                ViewBag.error = "State Already exist in data";
                return View();
            }
        }
        public ActionResult DeleteStateRecord(int id)
        {
            try
            {
                Istate.DeleteStateRecord(id);
                return RedirectToAction("DisplayState", "State");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public JsonResult GetStatesByCountryId(int id)
        {
            var states = Istate.GetStatesByCountryId(id);
            var json1 = JsonConvert.SerializeObject(states);
            return Json(json1, JsonRequestBehavior.AllowGet);
        }
    }
}