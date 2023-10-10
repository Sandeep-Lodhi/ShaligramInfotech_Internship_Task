using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandeepLodhi_ThemeIntegration_Task.Controllers
{
    public class UtilitiesController : Controller
    {
        // GET: Utilities
        public ActionResult ColorsView()
        {
            return View();
        }

        public ActionResult BordersView()
        {
            return View();
        }

        public ActionResult AnimationsView()
        {
            return View();
        }

        public ActionResult OthersView()
        {
            return View();
        }
    }
}