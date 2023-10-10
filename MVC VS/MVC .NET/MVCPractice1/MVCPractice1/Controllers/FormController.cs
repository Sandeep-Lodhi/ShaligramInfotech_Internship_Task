using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice1.Models;

namespace MVCPractice1.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //Parameters
        public string PostUsingParameters(string fname,string lname)
        {
            return "Form Parameters - " + fname + " , " + lname;
        }


        [HttpPost]
        //Request
        public string PostUsingRequest()
        {
            string fname = Request["fname"];
            string lname = Request["lname"];
            return "Form Parameters - " + fname + " , " + lname;
        }

        [HttpPost]
        //Form Collection
        public string PostUsingFormCollection(FormCollection form)
        {
            string fname = form["fname"];
            string lname = form["lname"];
            return "Form Parameters - " + fname + " , " + lname;
        }

        
        
        [HttpPost]
        //Strongly Binding
        public string PostUsingBinding(Form form)
        {
            return "Form Parameters - " + form.fname + " , " + form.lname;
        }

        [HttpPost]
        //Strongly Binding
        public ActionResult Validation(Form form)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                return View();
            }
            return View("Index");
        }
    }
}