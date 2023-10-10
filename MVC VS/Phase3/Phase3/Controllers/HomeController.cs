using Phase3.Models.DbContext;
using Phase3.Models.Model;
using Phase3.Repositaries.Interface;
using System.Linq;
using System.Web.Mvc;

namespace Phase3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home 
        IAuthInterface _IAuth;  //declare instance 
        public HomeController(IAuthInterface authInterface) //object
        {
            _IAuth = authInterface; //assign object to instance
        }
        public ActionResult Index()
        {

            return View(_IAuth.Index());
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(AuthModel data)
        {
            var result = _IAuth.Signup(data);
            if (result != 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //return View("Edit", _IAuth.Edit(Id));
            User user = _IAuth.GetUserById(Id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            Sandeep_Phase3Entities _DB = new Sandeep_Phase3Entities();
            var data = _DB.User.Where(x => x.Id == user.Id).FirstOrDefault();
            if (data != null)
            {
                data.Email = user.Email;
                data.UserName = user.UserName;
                data.Password = user.Password;
                //_DB.User.Add(user);
                _DB.Entry(data).State = System.Data.Entity.EntityState.Modified;
                _DB.SaveChanges();

            }
            return RedirectToAction("Index");

        }


        public ActionResult Details(int Id)
        {
            Sandeep_Phase3Entities _DB = new Sandeep_Phase3Entities();

            var data = _DB.User.Where(x => x.Id == Id).FirstOrDefault();  //_IAuth.Delete(Id);

            return View(data);
        }



        public ActionResult Delete(int Id)
        {
            Sandeep_Phase3Entities _DB = new Sandeep_Phase3Entities();
            var data = _DB.User.Where(x => x.Id == Id).FirstOrDefault();   //_IAuth.Delete(Id);
            
            _DB.User.Remove(data);
            _DB.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            RedirectToAction("Index");
            return View(data);
        }

    }
}