using Pagination_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Pagination_Entity.Controllers
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
        public ActionResult GetFilterdPaged(int pageSize,int currentPage,string searchText, int sortBy,string Address)
        {
            return View( Json(new UsersClass().GetFilteredUsers(currentPage, pageSize, searchText, sortBy, Address), JsonRequestBehavior.AllowGet));
      
        }
    }
}