﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThemeIntegrationMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


           public ActionResult Logout()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }
    }
}