using School_Management.Models.Model;
using School_Management.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Management.Controllers
{
    public class CountryController : Controller
    {
        ICountryInterface icountry;
        public CountryController(ICountryInterface _icountry)
        {
            icountry = _icountry;
        }
        public ActionResult Add_Country()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Country(CountryCustomModel customMdlctry)
        {
            try
            {
                string country = icountry.AddCountry(customMdlctry);

                if (country == "pass")
                {
                    return RedirectToAction("DisplayCountry", "Country");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult DisplayCountry()
        {
            try
            {
                List<CountryCustomModel> countrylist = new List<CountryCustomModel>();
                countrylist = icountry.GetCountryList();
                return View(countrylist);
            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }

        public ActionResult DeleteCountryRecord(int id)
        {
            try
            {
                icountry.DeleteCountryRecord(id);
                return RedirectToAction("DisplayCountry", "Country");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public ActionResult EditCountryRecord(int id)
        {
            try
            {
                var Edit = icountry.EditCouuntryRecord(id);
                return View(Edit);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult EditCountryRecord(CountryCustomModel customcountry)
        {
            icountry.UpdateCountry(customcountry);

            return RedirectToAction("DisplayCountry");
        }
    }

}