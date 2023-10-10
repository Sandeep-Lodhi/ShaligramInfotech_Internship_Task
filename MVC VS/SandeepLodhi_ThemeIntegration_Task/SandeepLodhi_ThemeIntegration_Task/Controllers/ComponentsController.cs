using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandeepLodhi_ThemeIntegration_Task.Controllers
{
    public class ComponentsController : Controller
    {
        // GET: Components
        public ActionResult ButtonsView()
        {
            return View();
        }

        public ActionResult CardsView()
        {
            return View();
        }
    }
}