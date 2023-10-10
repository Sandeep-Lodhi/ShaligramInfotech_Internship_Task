using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice1.Models;

namespace MVCPractice1.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
    {
        // GET: Employee

        [Route("")]
        public ActionResult Index()
        {
            var data = GetEmployee();
            return View(data);
        }

        [Route("I2")]
        //http://localhost:50867/Employee/Index1
        public ActionResult Index1()
        {
            return View("");
        }

        [Route("Index3")]
        // http://localhost:50867/Employee/Index2
        public ActionResult Index2()
        {
            return View("~/Views/Home/About.cshtml");
        }


        private Employee GetEmployee()
        {
            return new Employee()
            {
                Id = 1,
                Address="Amravati",
                Name="Krunal Dhote",
                DOB=DateTime.Now,
                email="krunal.d@shaligraminfotech.com",
                IsEmployee=true
            };
        }

        //Yahase get hoga sirf

        [Route("Form")]
        public ActionResult Form()
        {
            var data = GetEmployee();
            return View(data);
        }

        //Yaha Se post hoga sirf
        [HttpPost]
        public ActionResult Form(Employee emp)
        {
            return View();
        }
    }
}