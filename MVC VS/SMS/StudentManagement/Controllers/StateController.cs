using StudentManagement.AuthFilter;
using StudentManagement.Models.Models;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    [Authentication]
    public class StateController : Controller
    {
        ICountryInterface countryInterface;
        IStateInterface stateInterface;

        public StateController(ICountryInterface countryInterface, IStateInterface stateInterface)
        {
            this.countryInterface = countryInterface;
            this.stateInterface = stateInterface;
        }

        // GET: State
        public ActionResult CreateState(int? StateId)
        {
            ViewBag.CountryList = countryInterface.GetCountryList();

            if (StateId != null)
            {
                StateModel stateModel = stateInterface.GetStateByStateId((int)StateId);
                return View(stateModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateState(StateModel stateModel)
        {
            try
            {
                ViewBag.CountryList = countryInterface.GetCountryList();
                int success = stateInterface.CreateState(stateModel);
                if (success == 1)
                {
                    return RedirectToAction("RetriveStates");
                }
                else
                {
                    ViewBag.error = "Country Already Exist";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }


        public ActionResult RetriveStates()
        {
            return View(stateInterface.GetStates());
        }
    }
}