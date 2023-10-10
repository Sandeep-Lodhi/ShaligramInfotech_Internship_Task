using Signin_Login_practice.Models.DbContext;
using Signin_Login_practice.Models.Models;
using Signin_Login_practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Signin_Login_practice.Controllers
{
    public class HomeController : Controller
    {
        IRegister _Register;

        public HomeController(IRegister register)
        {
            _Register = register;
        }
        Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();


        public ActionResult Register()
        {
            ViewBag.GetCountry = _Register.GetCountry();
            ViewBag.getstate = new SelectList("");
            ViewBag.getcity = new SelectList("");
            return View();
        }

        [HttpPost]
        public ActionResult Register(CustomRegisterModel customRegisterModel)
        {

            string profile = Path.GetFileName(customRegisterModel.Profile.FileName);
            customRegisterModel.ProfilePic = "~/DocumentFiles/" + profile;
            customRegisterModel.Profile.SaveAs(Path.Combine(Server.MapPath("~/DocumentFiles/"), profile));

            string doc = Path.GetFileName(customRegisterModel.Documents.FileName);
            customRegisterModel.AttachmentDoc = "~/DocumentFiles/" + profile;
            customRegisterModel.Documents.SaveAs(Path.Combine(Server.MapPath("~/DocumentFiles/"), doc));

            _Register.Register(customRegisterModel);

            return RedirectToAction("Login", "Home");

        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomRegisterModel customRegisterModel)
        {
            var check = db.Registration.Where(x => x.Email.Equals(customRegisterModel.Email) && x.Password.Equals(customRegisterModel.Password)).FirstOrDefault();
            if (check != null)
            {
                Session["id"] = check.id.ToString();
                Session["Name"] = "Hello ! Welcome" + check.FirstName + check.LastName;
                TempData["Image"] = customRegisterModel.RePassword;
                TempData["success"] = "Login Successfully !";
                return RedirectToAction("Index","Home",new { id = check.id });
            }
            else
            {
                ViewBag.Notification = "Username or password is Wrong !";
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
           return RedirectToAction("Login", "Home");
        }

        public ActionResult Edit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ViewBag.GetCountry = _Register.GetCountry();
            ViewBag.GetState = new SelectList("");
            ViewBag.GetCity = new SelectList("");
            ViewBag.Hobbies = new SelectList("");

            var data = _Register.Edit(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(CustomRegisterModel customRegisterModel)
        {


            string profile = Path.GetFileName(customRegisterModel.Profile.FileName);
            customRegisterModel.ProfilePic = "~/DocumentFiles/" + profile;
            customRegisterModel.Profile.SaveAs(Path.Combine(Server.MapPath("~/DocumentFiles/"), profile));

                string doc = Path.GetFileName(customRegisterModel.Documents.FileName);
                customRegisterModel.AttachmentDoc = "~/DocumentFiles/" + profile;
                customRegisterModel.Documents.SaveAs(Path.Combine(Server.MapPath("~/DocumentFiles/"), doc));
            var data = db.Registration.Where(x => x.id == customRegisterModel.id).FirstOrDefault();
            if (data != null)
            {



                data.id = customRegisterModel.id;
                data.FirstName = customRegisterModel.FirstName;
                data.LastName = customRegisterModel.LastName;
                data.Email = customRegisterModel.Email;
                data.Password = customRegisterModel.Password;
                data.DOB = customRegisterModel.DOB;
                data.Address = customRegisterModel.Address;
                data.CountryId = customRegisterModel.CountryId;
                data.StateId = customRegisterModel.StateId;
                data.CityId = customRegisterModel.CityId;
                data.ProfilePic = customRegisterModel.ProfilePic;
                data.AttachmentDoc = customRegisterModel.AttachmentDoc;
                data.Gender = customRegisterModel.Gender;
                data.Hobbies = customRegisterModel.Hobbies;
                
                ViewBag.GetCountry = _Register.GetCountry();

                db.SaveChanges();
                return RedirectToAction("Index", "Home");



            }
            else
            {
                ViewBag.GetCountry = _Register.GetCountry();
                ViewBag.GetState = new SelectList("");
                ViewBag.GetCity = new SelectList("");
                return View();
            }

        }


        public ActionResult Index()
        {
            return View(_Register.index());
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


        public JsonResult GetState(int id)
        {
            ViewBag.GetState = _Register.GetState(id);
            return Json(ViewBag.GetState, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetCity(int id)
        {
            ViewBag.GetCity= _Register.GetCity(id);
            return Json(ViewBag.GetCity, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Details(int id)
        {
          
            var data = _Register.Details(id);
            if(data != null)
            {
                return View(data);
            }
            else
            {
            return View(data);
            }
        }


        public ActionResult Delete(int id)
        {
            _Register.Delete(id);
            ViewBag.Delete = "Record  deleted successfully !";
            return RedirectToAction("Index", "Home");
        }


    }
}