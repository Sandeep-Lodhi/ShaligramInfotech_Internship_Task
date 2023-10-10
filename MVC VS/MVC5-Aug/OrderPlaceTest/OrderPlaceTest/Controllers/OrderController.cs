using OrderPlaceTest.Models.DbContext;
using OrderPlaceTest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderPlaceTest.Controllers
{
    public class OrderController : Controller
    {
        Sit375DBEntities db = new Sit375DBEntities();
        // GET: Order
        public ActionResult Index()
        {
           
            return View(db.Order.ToList());
        }



        public ActionResult Details(int? id)
        {
            var data = db.Order.Where(x => x.OrderId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int? id)
        {
            var data = db.Order.Where(x => x.OrderId == id).FirstOrDefault();
            db.Order.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index", "Order");
        }

        [HttpPost]
        public ActionResult PlaceOrder(OrderModel om)
        {

            Order data = new Order();
            data.OrderId = om.OrderId;
            data.Details = om.Details;
            data.Amount = om.Amount;
            data.Status = om.Status;
            data.Cust_Id = om.Cust_Id;
            db.Order.Add(data);
            db.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult PlaceOrder()
        {
            return View();
        }

        public ActionResult MyOrder(int? id)
        {
            var fetch = db.Order.Where(x => x.Cust_Id == id).ToList();
            if (fetch != null)
            {
                ViewBag.Customer = id;
                
            }
            return View(fetch);
        }
    }
}