using SandeepMVC3_Test.Models.DbContext;
using SandeepMVC3_Test.Models.Models;
using SandeepMVC3_Test.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandeepMVC3_Test.Controllers
{
    public class AuthController : Controller
    {

        IAuth _Auth;

        public AuthController(IAuth auth)
        {
            _Auth = auth;
        }

        SandeepTestDBEntities db = new SandeepTestDBEntities();
        // GET: Auth

        public ActionResult Index(int id)

        {
            var data = _Auth.ShowUser(id);
            if (data != null)
            {
                TempData["show"] = "yes";
                return View(data);
            }
            else
            {
                return View();
            }
        }

        public ActionResult SignUp()
        {
            ViewBag.GetCountry = _Auth.GetCountry();
            ViewBag.GetState = new SelectList("");
            ViewBag.GetCity = new SelectList("");
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegistrationModel registrationModel)
        {
                  // For Images
            string filename = Path.GetFileName(registrationModel.Image.FileName);
            registrationModel.ProfilePic = "~/Document/" + filename;
            registrationModel.Image.SaveAs(Path.Combine(Server.MapPath("~/Document/"), filename));

            // For  Documents
            string docName = Path.GetFileName(registrationModel.Document.FileName);
            registrationModel.AttachmentDoc = "~/Document/" + docName;
            registrationModel.Document.SaveAs(Path.Combine(Server.MapPath("~/Document/"), docName));
            _Auth.SignUp(registrationModel);
            return RedirectToAction("Login", "Auth");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Auth");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegistrationModel registrationModel)
        {

            var checkLogin = db.Registration.Where(x => x.Email.Equals(registrationModel.Email) && x.Password.Equals(registrationModel.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["id"] = registrationModel.id.ToString();
                Session["Name"] = "Hello ! Welcome " + checkLogin.FirstName + checkLogin.LastName;
                TempData["success"] = "Login SuccessFul";


                return RedirectToAction("Index", "Auth", new { id = checkLogin.id });
            }
            else
            {
                ViewBag.Notification = "Wrong Username of password";

            }
            return View();
        }


        public JsonResult GetState(int id)
        {
            ViewBag.GetState = _Auth.GetState(id);

            return Json(ViewBag.GetState, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCity(int id)
        {
            ViewBag.GetCity = _Auth.GetCity(id);
            return Json(ViewBag.GetCity, JsonRequestBehavior.AllowGet);

        }

        //  [HttpGet]
        public ActionResult Edit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ViewBag.GetState = new SelectList("");
            ViewBag.GetCity = new SelectList("");
            // ViewBag.GetHobbies = new SelectList("");
            ViewBag.GetCountry = _Auth.GetCountry();
            var data = _Auth.Edit(id);
            //RedirectToAction("Edit", "Auth");
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(RegistrationModel registration)
        {
            var data = db.Registration.Where(x => x.id == registration.id).FirstOrDefault();
            if (data != null)
            {


                // For Images
                string filename = Path.GetFileName(registration.Image.FileName);
                registration.ProfilePic = "~/Document/" + filename;
                registration.Image.SaveAs(Path.Combine(Server.MapPath("~/Document/"), filename));

                // For  Documents
                string docName = Path.GetFileName(registration.Document.FileName);
                registration.AttachmentDoc = "~/Document/" + docName;
                registration.Document.SaveAs(Path.Combine(Server.MapPath("~/Document/"), docName));


                data.id = registration.id;
                data.FirstName = registration.FirstName;
                data.LastName = registration.LastName;
                data.Email = registration.Email;
                data.Password = registration.Password;
                data.DOB = registration.DOB;
                data.Address = registration.Address;
                data.CountryId = registration.CountryId;
                data.StateId = registration.StateId;
                data.CityId = registration.CityId;
                data.ProfilePic = registration.ProfilePic;
                data.AttachmentDoc = registration.AttachmentDoc;
                data.Gender = registration.Gender;
                data.Hobbies = registration.Hobbies;


         
                ViewBag.GetCountry = _Auth.GetCountry();


                //db.Entry(customAuthModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["success"] = "Update Successfully";
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                TempData["error"] = "Not Updated";
                ViewBag.GetState = new SelectList("");
                ViewBag.GetCity = new SelectList("");
                ViewBag.GetHobbies = new SelectList("");
                ViewBag.GetCountry = _Auth.GetCountry();
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            _Auth.Delete(id);
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("Index", "Home");
        }

    }
}