using CheckBox_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckBox_Practice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SandeepMVCEntities db = new SandeepMVCEntities();

            list_Hobbies lstHM = new list_Hobbies();
            lstHM.listHobbies = db.Hobbies.ToList<Hobbies>();
            ViewBag.message = Convert.ToString(TempData["message"]);

            return View(lstHM);
        }

        [HttpPost]
        public ActionResult Index(list_Hobbies obj_list)
        {
            var listhobbies = obj_list.listHobbies.Where(x => x.IsActive == true).ToList<Hobbies>();
            var result = Content(String.Join(",", listhobbies.Select(x => x.Hobby)));
            SandeepMVCEntities db = new SandeepMVCEntities();

            Student str = new Student();
            str.hobbies = result.Content.ToString();
            db.Student.Add(str);
            db.SaveChanges();

            TempData["message"] = "record succesfully added";
            return RedirectToAction("index", "Home");

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
    }
}