using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModels;
using DatabaseConnection;

namespace MVCPractice1.Controllers
{
    [RoutePrefix("Database")]
    public class DatabaseController : Controller
    {
        KrunalDhote351Entities db = new KrunalDhote351Entities();
        HotelManagementRepository repo = null;
        public DatabaseController()
        {
            repo = new HotelManagementRepository();
        }

        // GET: Database

        public ActionResult Create()
        {
            ViewBag.userType = new SelectList(db.UsersType2.ToList(), "UserTypeId", "UserTypeName");
            ViewBag.country = new SelectList(db.Countries.ToList(), "id", "CountryName");
            ViewBag.state = new SelectList(db.States.ToList(), "id", "StateName");
            ViewBag.city = new SelectList(db.Cities.ToList(), "id", "CityName");
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            ViewBag.userType = new SelectList(db.UsersType2.ToList(), "UserTypeId", "UserTypeName");
            ViewBag.country = new SelectList(db.Countries.ToList(), "id", "CountryName");
            ViewBag.state = new SelectList(db.States.ToList(), "id", "StateName");
            ViewBag.city = new SelectList(db.Cities.ToList(), "id", "CityName");
            if (ModelState.IsValid)
            {
                int id = repo.AddUser(user);
                if (id > 0)
                {
                    ModelState.Clear();
                }
            }

            return View();
        }

        public ActionResult GetAllUsers()
        {
            var result = repo.GetAllUsers();
            return View(result);
        }
        public ActionResult GetOneUser(int id)
        {
            var result = repo.GetOneUser(id);
            return View(result);
        }
        public ActionResult EditUserDeatils(int id)
        {
            ViewBag.userType = new SelectList(db.UsersType2.ToList(), "UserTypeId", "UserTypeName");
            ViewBag.country = new SelectList(db.Countries.ToList(), "id", "CountryName");
            ViewBag.state = new SelectList(db.States.ToList(), "id", "StateName");
            ViewBag.city = new SelectList(db.Cities.ToList(), "id", "CityName");

            var result = repo.GetOneUser(id);
            return View(result);
        }
        
        [HttpPost]
        public ActionResult UpdateUserDeatils(UserModel user)
        {
            ViewBag.userType = new SelectList(db.UsersType2.ToList(), "UserTypeId", "UserTypeName");
            ViewBag.country = new SelectList(db.Countries.ToList(), "id", "CountryName");
            ViewBag.state = new SelectList(db.States.ToList(), "id", "StateName");
            ViewBag.city = new SelectList(db.Cities.ToList(), "id", "CityName");

            if (ModelState.IsValid)
            {
                repo.UpdateUser(user.Id, user);
                ModelState.Clear();
                return RedirectToAction("GetOneUser",new { id = user.Id });
            }
            return RedirectToAction("GetAllUsers");
        }

     
        public ActionResult DeleteUser(int id)
        {
            repo.DeleteUser(id);
            return RedirectToAction("GetAllUsers");
        }
    }
}