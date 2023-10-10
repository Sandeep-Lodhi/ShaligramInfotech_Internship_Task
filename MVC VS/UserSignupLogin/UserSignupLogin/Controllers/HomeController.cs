using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSignupLogin.Models;
namespace UserSignupLogin.Controllers
{
    public class HomeController : Controller
    {
        SandeepMVCEntities db = new SandeepMVCEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.TBLUserInfo.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

  
        [HttpPost]
        public ActionResult Signup(TBLUserInfo tBLUserInfo)
        {
            if (db.TBLUserInfo.Any(x=>x.UsernameUs == tBLUserInfo.UsernameUs))
            {
                ViewBag.Notification = "This is account has aleady existed";
               return View();
            }
            else
            {
                db.TBLUserInfo.Add(tBLUserInfo);
                db.SaveChanges();

                Session["IdUsSS"] = tBLUserInfo.IdUs.ToString();
                Session["UsernameSS"] = tBLUserInfo.UsernameUs.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Login(TBLUserInfo tBLUserInfo)
        {
            var checkLogin = db.TBLUserInfo.Where(x => x.UsernameUs.Equals(tBLUserInfo.UsernameUs) && x.PasswordUs.Equals(tBLUserInfo.PasswordUs)).FirstOrDefault();
            if(checkLogin !=null)
            {
                Session["IdUsSS"] = tBLUserInfo.IdUs.ToString();
                Session["UsernameSS"] = tBLUserInfo.UsernameUs.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong Username of password";

            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int IdUs)
        {
            var data = db.TBLUserInfo.Where(x => x.IdUs == IdUs).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(TBLUserInfo tBLUserInfo)
        {
            var data = db.TBLUserInfo.Where(x => x.IdUs == tBLUserInfo.IdUs).FirstOrDefault();
            if(data != null)
            {
                data.UsernameUs = tBLUserInfo.UsernameUs;
                data.PasswordUs = tBLUserInfo.PasswordUs;
                db.TBLUserInfo.Add(tBLUserInfo);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int IdUs)
        {
            var data = db.TBLUserInfo.Where(x => x.IdUs == IdUs).FirstOrDefault();
            return View(data);
        }

        public  ActionResult Delete(int IdUs)
        {
            var data = db.TBLUserInfo.Where(x => x.IdUs == IdUs).FirstOrDefault();
            db.TBLUserInfo.Remove(data);
            db.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("Index");
        }
    }

   
}