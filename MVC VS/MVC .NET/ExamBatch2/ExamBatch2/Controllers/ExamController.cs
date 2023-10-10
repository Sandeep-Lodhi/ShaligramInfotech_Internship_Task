using Exam.Models.Models;
using Exam.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamBatch2.Controllers
{
    public class ExamController : Controller
    {
        ExamInterface _IExam;
        public ExamController(ExamInterface ExamInterface)
        {
            _IExam = ExamInterface;
        }
        // GET: Exam
        public ActionResult Index(string user)
        {
            ViewBag.User = user;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = _IExam.LoginUser(user);
                if (result)
                {
                    Session["UserName"] = user.UserName;
                    SessionHelper.SessionHelper.Username = user.UserName;
                    return RedirectToAction("Index","Exam",new {username=user.UserName });
                }
                ViewBag.Message = "Invalid UserName and Password Entered!";
                return View();
            }
            else
            {
                return View();
            }
        }
        public JsonResult GetUserName(string username)
        {
            var result = _IExam.GetUserName(username);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //Quiz
        public JsonResult GetQuestions()
        {
            var result = _IExam.GetQuestions();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public void Logout()
        {
            Session.Clear();
        }


    }
}