using MyApp.Models;
using System.Web.Mvc;
using MyApp.Db.DbOperations;

namespace DataBaseConnection.Controllers
{
    public class HomeController : Controller
    {
        readonly EmployeeReposatery repository = null;

        public HomeController()
        {
            repository = new EmployeeReposatery();
        }
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmoloyeeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddEmployee(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                }
            }
            return View();
        }
    }
}
