using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice1.Models;

namespace MVCPractice1.Controllers
{
    public class ViewController : Controller
    {
        // GET: View
        public ActionResult Index()
        {
            ViewBag.myProp = "Value";
            ViewBag.myProp2 = "Value 2";
            ViewBag.myList = new List<string>() { "Krunal", "Piyush", "Shuvam", "Kirtan", "Raj" };

            List<Employee> empList = new List<Employee>()
            {
                new Employee(){email="a@hfd",Id=1,Name="asasas"},
                new Employee(){email="b@hfd",Id=2,Name="bbasas"},
                new Employee(){email="c@hfd",Id=3,Name="xxasas"},
                new Employee(){email="d@hfd",Id=4,Name="ccccsas"}
            };

            ViewBag.emp = empList;


            ViewData["key"] = "This is Krunal";

            TempData["temp"] = "This is tempdata";
            TempData.Keep();

            return View();
        }

        public ActionResult Temp()
        {
            ViewBag.Temp = TempData["temp"];
            TempData.Keep();
            return View();
        }
    }
}