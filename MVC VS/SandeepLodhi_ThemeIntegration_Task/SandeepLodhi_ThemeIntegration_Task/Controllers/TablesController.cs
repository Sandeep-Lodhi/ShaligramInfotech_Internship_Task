using SandeepLodhi_ThemeIntegration_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandeepLodhi_ThemeIntegration_Task.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public ActionResult Tables()
        {
            List<Employee> list = new List<Employee>()
            {
               new Employee()
               {
                    Id = 1,
                    Name = "Mudassar",
                    Address = "Abbottabad",
                    City = "Abbottabad Pakistan",
                    Country = "Paksistan"
               },
               new Employee()
               {
                    Id = 2,
                    Name = "Asad",
                    Address = "Abbottabad",
                    City = "Abbottabad Pakistan",
                    Country = "Paksistan"
                },
                 new Employee()
                 {
                    Id = 3,
                    Name = "Mubashir",
                    Address = "Abbottabad",
                    City = "Abbottabad Pakistan",
                    Country = "Paksistan"
                 },
            };
            ViewBag.model = list;
            return View();
        }
    }
 }   