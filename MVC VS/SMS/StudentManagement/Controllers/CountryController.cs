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
    public class CountryController : Controller
    {

        ICountryInterface countryInterface;


        public CountryController(ICountryInterface countryInterface)
        {
            this.countryInterface = countryInterface;
        }
        // GET: Country
        public ActionResult CreateCountry(int? CountryId)
        {
            ViewBag.Action = "Create";
            if (CountryId != null)
            {
                CountryModel countryModel = countryInterface.GetCountryById((int)CountryId);
                ViewBag.Action = "Update";
                return View(countryModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateCountry(CountryModel countryModel)
        {
            try
            {
                int success = countryInterface.CreateNewCountry(countryModel);
                if (success == 1)
                {
                    return RedirectToAction("RetriveCountries");
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

        public ActionResult RetriveCountries()
        {
            try
            {
                return View(countryInterface.GetCountryList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}