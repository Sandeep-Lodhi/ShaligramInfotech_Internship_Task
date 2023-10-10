using Newtonsoft.Json;
using Sandeep_Bootstrappractice.Models.DbContext;
using Sandeep_Bootstrappractice.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandeep_Bootstrappractice.Controllers
{
    public class HomeController : Controller
    {
        Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();
        public ActionResult Index()
        {
            return View(db.Registration.ToList());
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel registrationModel)
        {
            Registration registration = new Registration();

            // For Images
            string filename = Path.GetFileName(registrationModel.Image.FileName);
            registrationModel.ProfilePic = "~/Documents/" + filename;
            registrationModel.Image.SaveAs(Path.Combine(Server.MapPath("~/Documents/"), filename));

            // For  Documents
            string docName = Path.GetFileName(registrationModel.Document.FileName);
            registrationModel.AttachmentDoc = "~/Documents/" + docName;
            registrationModel.Document.SaveAs(Path.Combine(Server.MapPath("~/Documents/"), docName));

            registration.id = registrationModel.id;
            registration.FirstName = registrationModel.FirstName;
            registration.LastName = registrationModel.LastName;
            registration.Email = registrationModel.Email;
            registration.Password = registrationModel.Password;
            registration.DOB = registrationModel.DOB;
            registration.Address = registrationModel.Address;
            registration.CountryId = registrationModel.CountryId;
            registration.StateId = registrationModel.StateId;
            registration.CityId = registrationModel.CityId;
            registration.ProfilePic = registrationModel.ProfilePic;
            registration.AttachmentDoc = registrationModel.AttachmentDoc;
            registration.Gender = registrationModel.Gender;
            registration.Hobbies = registrationModel.Hobbies;

            db.Registration.Add(registration);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }


        public JsonResult GetCountry()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Country> country = db.Country.ToList();
            var jsonList = JsonConvert.SerializeObject(country);
            return Json(jsonList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetState(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<State> states = db.State.Where(x => x.Cid == id).ToList();
            var jsonList = JsonConvert.SerializeObject(states);
            return Json(jsonList, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetCity(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<City> city = db.City.Where(x => x.Sid == id).ToList();
            var jsonList = JsonConvert.SerializeObject(city);
            return Json(jsonList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Logout()
        {
            Session.Clear();
           return  RedirectToAction("Login", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegistrationModel registrationModel)
        {
           var CheckLogin = db.Registration.Where(x => x.Email.Equals(registrationModel.Email)  && x.Password.Equals(registrationModel.Password)).FirstOrDefault();

            if(CheckLogin != null)
            {
                Session["id"] = registrationModel.id;
                Session["Name"] = "Hello"+" "+CheckLogin.FirstName+" "+ CheckLogin.LastName;
                Session["Success"] = "User Login Successfully!";
                return RedirectToAction("Index", "Home", new { id = CheckLogin.id });
            }
            else
            {
                ViewBag.Notification = "Username or Password Wrong ! Try Again...";
            }
            return View();
               
        }

        public ActionResult Edit(int id)
        {
            Registration registration = db.Registration.Where(x => x.id == id).FirstOrDefault();
            RegistrationModel registrationModel = new RegistrationModel();

            registrationModel.id = registration.id;
            registrationModel.FirstName = registration.FirstName;
            registrationModel.LastName = registration.LastName;
            registrationModel.Email = registration.Email;
            registrationModel.Password = registration.Password;
            registrationModel.DOB = registration.DOB;
            registrationModel.Address = registration.Address;
            registrationModel.CountryId = registration.CountryId;
            registrationModel.StateId = registration.StateId;
            registrationModel.CityId = registration.CityId;
            registrationModel.ProfilePic = registration.ProfilePic;
            registrationModel.AttachmentDoc = registration.AttachmentDoc;
            registrationModel.Gender = registration.Gender;
            registrationModel.Hobbies = registration.Hobbies;

            return View(registrationModel);
        }

        [HttpPost]
        public ActionResult Edit(RegistrationModel registrationModel)
        {

            var data = db.Registration.Where(x => x.id == registrationModel.id).FirstOrDefault();
            if(data != null)
            {
                //// For Images
                // string filename = Path.GetFileName(registrationModel.Image.FileName);
                //registrationModel.ProfilePic = "~/Documents/" + filename;
                //registrationModel.Image.SaveAs(Path.Combine(Server.MapPath("~/Documents/"), filename));

                //// For  Documents
                //string docName = Path.GetFileName(registrationModel.Document.FileName);
                //registrationModel.AttachmentDoc = "~/Documents/" + docName;
                //registrationModel.Document.SaveAs(Path.Combine(Server.MapPath("~/Documents/"), docName));

                data.id = registrationModel.id;
                data.FirstName = registrationModel.FirstName;
                data.LastName = registrationModel.LastName;
                data.Email = registrationModel.Email;
                data.Password = registrationModel.Password;
                data.DOB = registrationModel.DOB;
                data.Address = registrationModel.Address;
                data.CountryId = registrationModel.CountryId;
                data.StateId = registrationModel.StateId;
                data.CityId = registrationModel.CityId;
                data.ProfilePic = registrationModel.ProfilePic;
                data.AttachmentDoc = registrationModel.AttachmentDoc;
                data.Gender = registrationModel.Gender;
                data.Hobbies = registrationModel.Hobbies;

                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var data = db.Registration.Where(x => x.id == id).FirstOrDefault();

            return View(data);

        }

        public ActionResult Delete(int id)
        {
            var data = db.Registration.Where(x => x.id == id).FirstOrDefault();
            db.Registration.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}