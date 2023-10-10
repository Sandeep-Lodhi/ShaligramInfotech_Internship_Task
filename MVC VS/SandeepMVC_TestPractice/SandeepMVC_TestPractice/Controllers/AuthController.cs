using SandeepMVC_TestPractice.ActionHelper;
using SandeepMVC_TestPractice.Helpers.GlobalEnums;
using SandeepMVC_TestPractice.Helpers.Helpers;
using SandeepMVC_TestPractice.Models.DbContext;
using SandeepMVC_TestPractice.Models.Models;
using SandeepMVC_TestPractice.Repository.Interface;
using SandeepMVC_TestPractice.Repository.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SandeepMVC_TestPractice.Helpers.GlobalEnums.HobbiesEnum;

  namespace SandeepMVC_TestPractice.Controllers
{
   
    public class AuthController : Controller
    {
        // GET: Auth
        IAuth _Auth;

        public AuthController(IAuth auth)
        {
            _Auth = auth;
        }

        Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();

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
      
           // ViewBag.GetHobbies = new SelectList("");
            ViewBag.GetCountry = _Auth.GetCountry();
            ViewBag.GetState = new SelectList("");
            ViewBag.GetCity = new SelectList("");
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(CustomAuthModel customAuthModel)
        {


            // For Images
            string filename = Path.GetFileName(customAuthModel.Image.FileName);
            customAuthModel.ProfilePic = "~/Content/Attachments/" + filename;
            customAuthModel.Image.SaveAs(Path.Combine(Server.MapPath("~/Content/Attachments/"), filename));

            // For  Documents
            string docName = Path.GetFileName(customAuthModel.Document.FileName);
            customAuthModel.AttachmentDoc = "~/Content/Attachments/" + docName;
            customAuthModel.Document.SaveAs(Path.Combine(Server.MapPath("~/Content/Attachments/"), docName));


            _Auth.SignUp(customAuthModel);


            return RedirectToAction("Login","Auth");
        }


        //[CustomActionFilter]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Auth");
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomAuthModel customAuthModel)
        {
            
            var checkLogin = db.Registration.Where(x => x.Email.Equals(customAuthModel.Email) && x.Password.Equals(customAuthModel.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["id"] = customAuthModel.id.ToString();
                Session["Name"] = "Hello ! Welcome " + checkLogin.FirstName + checkLogin.LastName;
                TempData["success"] = "Login SuccessFul";


                return RedirectToAction("Index", "Auth",new { id=checkLogin.id });
            }
            else
            {
                ViewBag.Notification = "Wrong Username of password";

            }
            return View();
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
        public ActionResult Edit(CustomAuthModel customAuthModel)
        {
            var data = db.Registration.Where(x => x.id == customAuthModel.id).FirstOrDefault();
            if (data != null)
            {


                // For Images
                string filename = Path.GetFileName(customAuthModel.Image.FileName);
                customAuthModel.ProfilePic = "~/Content/Attachments/" + filename;
                customAuthModel.Image.SaveAs(Path.Combine(Server.MapPath("~/Content/Attachments/"), filename));

                // For  Documents
                string docName = Path.GetFileName(customAuthModel.Document.FileName);
                customAuthModel.AttachmentDoc = "~/Content/Attachments/" + docName;
                customAuthModel.Document.SaveAs(Path.Combine(Server.MapPath("~/Content/Attachments/"), docName));

             
                data.id = customAuthModel.id;
                data.FirstName = customAuthModel.FirstName;
                data.LastName = customAuthModel.LastName;
                data.Email = customAuthModel.Email;
                data.Password = customAuthModel.Password;
                data.DOB = customAuthModel.DOB;
                data.Address = customAuthModel.Address;
                data.CountryId = customAuthModel.CountryId;
                data.StateId = customAuthModel.StateId;
                data.CityId = customAuthModel.CityId;
                data.ProfilePic = customAuthModel.ProfilePic;
                data.AttachmentDoc = customAuthModel.AttachmentDoc;
                data.Gender = customAuthModel.Gender;
                data.Hobbies = customAuthModel.Hobbies;

            
                //ModelState.Clear();
                //ViewBag.GetState = new SelectList("");
                //ViewBag.GetCity = new SelectList("");
                //ViewBag.GetHobbies = new SelectList("");
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
            return RedirectToAction("Index","Home");
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


        
    }
}