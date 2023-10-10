using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        // http://localhost:50867/Home/Name
        public string Name()
        {
            return "My Name Is Krunal";
        }

        // http://localhost:50867/Home/Profile?id=9
        // Parameterized Methode
        public string Profile(int id)
        {
            string profile = string.Empty;
            if (id == 351)
            {
                profile = "My Name Is Krunal";
            }else if (id == 361)
            {
                profile = "My Name Is Piyush";
            }
            else
            {
                profile = "No Profile Found";
            }
            return profile;
        }

        //two parameter with null or default value
        //  http://localhost:50867/Home/TwoPara?id=9
        //  http://localhost:50867/Home/TwoPara?id=9&num=9
        //  http://localhost:50867/Home/TwoPara?id=9&i=9&num=9
        public string TwoPara(int id,int? num = 6,int? i= null)
        {
            return "id : "+id + " dept : "+num+ i;  //concat no addition
        }
    }
}