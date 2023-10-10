using Exam.Models.DBContext;
using Exam.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Helpers.Helpers
{
    public class ExamHelper
    {
        public static CustomerMaster RegisterCustomer(CustomerModel c) {
            CustomerMaster customer = new CustomerMaster
            {
                Name=c.Name,
                Email=c.Email,
                Password=c.Password
            };
            return customer;
        }
        public static OrdersMaster PlaceOrder(OrderModel o) {
            OrdersMaster order = new OrdersMaster
            {
                OrderDate=o.OrderDate,
                PromoCode=o.PromoCode,
                Amount=o.Amount,
                PayingAmount=o.PayingAmount,
                AfterGST=o.AfterGST,
                CGST=o.CGST,
                SGST=o.SGST,
                CustId=o.CustId
            };
            return order;
        }

    }
}
