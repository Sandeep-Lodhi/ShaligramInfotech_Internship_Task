using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPractice1.Models;

namespace MVCPractice1.Controllers
{
   
    public class StudentController : Controller
    {

        [Route("students")]
        // GET: Student

        //http://localhost:50867/Student/GetAllStudents
        public ActionResult GetAllStudents()
        {
            var student = Students();
            return View(student);
        }

        [Route("students/{id}")]
        //http://localhost:50867/Student/GetStdent?id=1
        public ActionResult GetStdent(int id)
        {
            var student = Students().FirstOrDefault(x=>x.Id==id);
            return View(student);
        }

        [Route("students/{id}/Address")]
        //http://localhost:50867/Student/GetStdentAddress?id=1
        public ActionResult GetStdentAddress(int id)
        {
            var studentAddress = Students().Where(x => x.Id == id).Select(x => x.Address);
            return View();
        }


        private List<Student> Students()
        {
            return new List<Student>()
            {
                
                new Student()
                {
                    Id=1,
                    Name="Krunal Dhote",
                    Class="C",
                    Address=new Address()
                    {
                        City="Amravati",
                        State="Maharashtra",
                        Country="India"
                    }
                },
                new Student()
                    {
                        Id=2,
                        Name="Piyush Sinha",
                        Class="A",
                        Address=new Address()
                        {
                            City="Gaya",
                            State="Bihar",
                            Country="India"
                        }
                    }

            };
        }
    }
}