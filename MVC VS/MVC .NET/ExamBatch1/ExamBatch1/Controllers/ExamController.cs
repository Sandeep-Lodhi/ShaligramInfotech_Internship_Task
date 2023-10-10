using Exam.Models.Models;
using Exam.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ExamBatch1.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        ExamInterface _IExamInterface;
        public ExamController(ExamInterface IExamInterface)
        {
            _IExamInterface = IExamInterface;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Register(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                int result = _IExamInterface.registerCustomer(customer);
                if (result > 0)
                {
                    return View("Login");
                }
            }
            return View();
        }


        public ActionResult Login() {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email,string pass)
        {
            int result = _IExamInterface.loginUser(email, pass);
            if (result>0) {
                SessionHelper.Sessions.username = email;
                Session["Username"] = email;
                return RedirectToAction("Cart",new { id = result });
            }
            return View();
        }

       
        public JsonResult GetItemsList() {
            var result = _IExamInterface.GetItems();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoupenList() {
            var result = _IExamInterface.GetCoupen();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cart(int id)
        {
            ViewBag.Customer = id;
            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(OrderModel order)
        {
            var result=_IExamInterface.PlaceOrder(order);
            if (result > 0)
            {
                return Json("Order Successfull",JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Cart", new { id = order.CustId } );
        }
        [ActionFilterHelper.ActionFilterHelper]
        public ActionResult MyOrder(int id)
        {
            var result = _IExamInterface.GetOrderByID(id);
            ViewBag.Customer = id;
            return View(result);
        }

        public JsonResult GetOrderByDate(int id,DateTime? from,DateTime? to)
        {
            var result = _IExamInterface.GetOrderByDate(id,from,to);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Exam");
        }
    }
}