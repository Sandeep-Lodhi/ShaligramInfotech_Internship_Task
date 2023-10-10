using PagedList; 
using SandeepMVC_TestPractice.Models;
using SandeepMVC_TestPractice.Models.DbContext;
using SandeepMVC_TestPractice.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandeepMVC_TestPractice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Auth
        IAuth _Auth;

        public HomeController(IAuth auth)
        {
            _Auth = auth;
        }


        public ActionResult index()
        {
            Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();

    

            return View(_Auth.index());
        }

        //public ActionResult index(string option, string search, int? pageNumber, string sort)
        //{

        //    Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();

        //    //if the sort parameter is null or empty then we are initializing the value as descending name  

        //    ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
        //    //if the sort value is gender then we are initializing the value as descending gender  
        //    ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

        //    //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
        //    var records = db.Registration.AsQueryable();


        //    if (option == "Subjects")
        //    {
        //        View(db.Registration.Where(x => x.FirstName == search || search == null).ToList());
        //    }
        //    else if (option == "Gender")
        //    {
        //        View(db.Registration.Where(x => x.Gender == search || search == null).ToList());
        //    }
        //    else
        //    {
        //        View(db.Registration.Where(x => x.Email.StartsWith(search) || search == null).ToList());
        //    }

        //    switch (sort)
        //    {

        //        case "descending name":
        //            records = records.OrderByDescending(x => x.FirstName);
        //            break;

        //        case "descending gender":
        //            records = records.OrderByDescending(x => x.Gender);
        //            break;

        //        case "Gender":
        //            records = records.OrderBy(x => x.Gender);
        //            break;

        //        default:
        //            records = records.OrderBy(x => x.FirstName);
        //            break;

        //    }
        //    _Auth.index(option, search, pageNumber, sort);
        //    return View(records);
        //}

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


        //[HttpGet]
        //public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        //{
        //    Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();
        //    int pageSize = 10;
        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
        //    ViewBag.CurrentSort = sortOrder;
        //    sortOrder = String.IsNullOrEmpty(sortOrder) ? "FirstName" : sortOrder;
        //    IPagedList<Registration> register = null;
        //   // register = (IPagedList<Registration>)_Auth.index();
        //    switch (sortOrder)
        //    {
        //        case "FirstName":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.FirstName).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.FirstName).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "LastName":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.LastName).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.LastName).ToPagedList(pageIndex, pageSize);
        //            break;
        //        case "Email":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.Email).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.Email).ToPagedList(pageIndex, pageSize);
        //            break;
        //        case "Password":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.Password).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.Password).ToPagedList(pageIndex, pageSize);
        //            break;
        //        case "DOB":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.DOB).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.DOB).ToPagedList(pageIndex, pageSize);
        //            break;
        //        case "Address":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.Address).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.Address).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "CountryId":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.CountryId).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.CountryId).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "StateId":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.StateId).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.StateId).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "CityId":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.CityId).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.CityId).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "ProfilePic":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.ProfilePic).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.ProfilePic).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "AttachmentDoc":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.AttachmentDoc).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.AttachmentDoc).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "Gender":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.Gender).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.Gender).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "Hobbies":
        //            if (sortOrder.Equals(CurrentSort))
        //                register = db.Registration.OrderByDescending
        //                        (m => m.Hobbies).ToPagedList(pageIndex, pageSize);
        //            else
        //                register = db.Registration.OrderBy
        //                        (m => m.Hobbies).ToPagedList(pageIndex, pageSize);
        //            break;

        //        case "Default":
        //            register = db.Registration.OrderBy
        //                (m => m.FirstName).ToPagedList(pageIndex, pageSize);
        //            break;

        //    }
        //    return View(register);
        //}

        //the first parameter is the option that we choose and the second parameter will use the textbox value  

        // -----------------------------------------------------------------------------------------------
        //public ActionResult Index(string option, string search, int? pageNumber, string sort)
        //{
        //    Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();

        //    //if the sort parameter is null or empty then we are initializing the value as descending name  

        //    ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
        //    //if the sort value is gender then we are initializing the value as descending gender  
        //    ViewBag.SortByGender = sort == "Gender" ? "descending gender" : "Gender";

        //    //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
        //    var records = db.Registration.AsQueryable();


        //    if (option == "Subjects")
        //    {
        //        View(db.Registration.Where(x => x.FirstName == search || search == null).ToList());
        //    }
        //    else if (option == "Gender")
        //    {
        //        View(db.Registration.Where(x => x.Gender == search || search == null).ToList());
        //    }
        //    else
        //    {
        //        View(db.Registration.Where(x => x.Email.StartsWith(search) || search == null).ToList());
        //    }

        //    switch (sort)
        //    {

        //        case "descending name":
        //            records = records.OrderByDescending(x => x.FirstName);
        //            break;

        //        case "descending gender":
        //            records = records.OrderByDescending(x => x.Gender);
        //            break;

        //        case "Gender":
        //            records = records.OrderBy(x => x.Gender);
        //            break;

        //        default:
        //            records = records.OrderBy(x => x.FirstName);
        //            break;

        //    }
           
        //     return View(_Auth.index( option, search, pageNumber, sort));

        //}
    }
}