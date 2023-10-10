using Crud_Practice_4.Model.DB.Context;
using Crud_Practice_4.Model.Model;
using Crud_Practice_4.Reposatory.Inserface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Practice_4.Controllers
{
    public class Add_dataController : Controller

    {
        Jatin_dEntities2 db = new Jatin_dEntities2();
        public IUserInterface1 IUser_Interface1;
        private int id;

        // GET: Add_data

        public ActionResult Add_result()
        {
            List<student> stud = db.student.ToList();
            return View(stud);
        }

        public ActionResult add_new_data()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_new_data(User_Model user_Model)
        {
            try
            {
                var match = db.student.Any(x => x.First_Name.ToString().ToUpper() == user_Model.Firstname.ToString().ToUpper() && x.Last_Name.ToString().ToUpper() == user_Model.Lastname.ToString().ToUpper() && x.Email.ToString().ToUpper() == user_Model.Email.ToString().ToUpper() && x.Mobile_Number == user_Model.MobileNumber);
                if (!match)
                {
                    student stu_data = new student();
                    stu_data.stu_id = user_Model.id;
                    stu_data.First_Name = user_Model.Firstname;
                    stu_data.Last_Name = user_Model.Lastname;
                    stu_data.Age = user_Model.Age;
                    stu_data.Email = user_Model.Email;
                    stu_data.Mobile_Number = user_Model.MobileNumber;
                    stu_data.Pass_word = user_Model.password;
                    db.student.Add(stu_data);
                    db.SaveChanges();
                    TempData[""] = "Data Added";
                    return RedirectToAction("Add_result", "Add_data");
                }
                else
                {
                    TempData[""] = "Duplicate Values Someone";
                    return View();
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult DeleteUser(int id)
        {
            var del = db.student.Where(x => x.stu_id == id).FirstOrDefault();
            db.student.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Add_result", "Add_data");

        }

        public ActionResult Edit(int id)
        {
            Jatin_dEntities2 db = new Jatin_dEntities2();
            student ed = db.student.Where(x => x.stu_id == id).FirstOrDefault();
            User_Model user = new User_Model();
            user.id = ed.stu_id;
            user.Firstname = ed.First_Name;
            user.Lastname = ed.Last_Name;
            user.Age = (int)ed.Age;
            user.MobileNumber = ed.Mobile_Number;
            user.Email = ed.Email;
            user.password = ed.Pass_word;

            return View(user);
            
        }
       
        [HttpPost]
        public ActionResult edit(User_Model user)
        {
            if (user.id > 0)
            {
                Jatin_dEntities2 db = new Jatin_dEntities2();
            }

                var student_id = db.student.Where(x => x.stu_id == user.id).FirstOrDefault();
                if (student_id != null)
                {
                    student_id.stu_id = user.id;
                    student_id.First_Name = user.Firstname;
                    student_id.Last_Name = user.Lastname;
                    student_id.Age = user.Age;
                    student_id.Email = user.Email;
                    student_id.Mobile_Number = user.MobileNumber;
                    student_id.Pass_word = user.password;
                    db.Entry(student_id).State = EntityState.Modified;
                    db.SaveChanges();
                }     
            


            return RedirectToAction("Add_result");
        }

    public ActionResult Details()
        {
             Jatin_dEntities2 db = new Jatin_dEntities2();
            student ed = db.student.Where(x => x.stu_id == id).FirstOrDefault();

            return View();
        }



    }
}