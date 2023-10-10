using Kirtan_375_Test.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models.Model;
using Test.Repository.Repository;

namespace Kirtan_375_Test.Controllers
{
    [LoginFilter]
    public class DashController : Controller
    {
        // GET: Dash
        public IOrder orderdetails;
        public IItems itemdetails;

        public DashController (IOrder _order, IItems _item)
        {
            orderdetails = _order;
            itemdetails = _item;
        }

        //List<int> Total = new List<int>();
        public ActionResult Order()
        {
            ViewBag.ses = Session["IsLoggedIn"];
            ViewBag.itemList = itemdetails.GetItems();
            ViewBag.orderList = orderdetails.GetOrderDetails_Results();
            var result = orderdetails.GetOrderDetails_Results().ToList();
            int TotalAmount = (int)result.Sum(x => x.total);
            ViewBag.totalamount = TotalAmount;
            int Gst = (TotalAmount * 5) / 100;
            ViewBag.gst = Gst;
            int NetAmount = TotalAmount - (2 * Gst);
            ViewBag.payable = NetAmount;
            return View();
        }
        
        [HttpPost]
        public ActionResult Order(OrderModel orderData)
        {
            try
            {
                if (orderData != null)
                {
                    orderData.UserId = (int)Session["IsLoggedIn"];
                    orderdetails.AddOrder(orderData);
                    return RedirectToAction("Order");
                }
                return View();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        
        public ActionResult UpdateOrder(int id)
        {
            OrderModel orderDetails = new OrderModel() 
            { 
                Id = orderdetails.GetOrderId(id).id,
                Quantity = (int)orderdetails.GetOrderId(id).quantity
            };

            return View(orderDetails);
        }

        [HttpPost]
        public ActionResult UpdateOrder(int id, OrderModel orderDetails)
        {
            ViewBag.itemList = itemdetails.GetItems();
            ViewBag.orderList = orderdetails.GetOrderDetails_Results();
            orderdetails.UpdateOrder(id, orderDetails);
            return RedirectToAction("Order");
        }

        public ActionResult DeleteOrder(int id)
        {
            orderdetails.Orderdelete(id);
            return RedirectToAction("Order");
        }

        public ActionResult Logout()
        {
            Session["isLoggedIn"] = null;
            Session.Clear();
            Session.Abandon();
            return Redirect("Order");
        }

        
    }
}