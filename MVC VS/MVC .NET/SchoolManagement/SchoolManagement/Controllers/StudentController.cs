using School.Models.Models;
using School.Repository.Interface;
using SchoolManagement.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        IStudentInterface _studentInterface;
        public StudentController(IStudentInterface studentInterface)
        {
            _studentInterface = studentInterface;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            try
            {
                var result=_studentInterface.LoginStudent(email, password);
                if (result == 0)
                {
                    return View();
                }
                SessionHelper.LoginSession.Email = email;
                return RedirectToAction("GetDetails");
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Register(int id=0)
        {
            if (id > 0)
            {
                var result = _studentInterface.GetOneDetail(id);
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(StudentModel student)
        {
            try {
                if (ModelState.IsValid)
                {
                    var result=_studentInterface.RegisterStudent(student);
                    if (result == 0)
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                return View();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        
        [MyActionFilter]
        public ActionResult GetDetails()
        {
            try {
                
                var result=_studentInterface.GetDetails();
                if (result != null)
                {
                    return View(result);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult DeleteStudent(int id)
        {
            try {
                
                var result=_studentInterface.DeleteStudent(id);
                if (result)
                {
                    return View("GetDetails");
                }
                else
                {
                    return RedirectToAction("GetDetails");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateStudent(int id)
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}