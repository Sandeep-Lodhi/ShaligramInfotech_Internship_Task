using StudentManagement.AuthFilter;
using StudentManagement.Models;
using StudentManagement.Models.Context;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    [Authentication]
    public class DashboardController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
    }
}

