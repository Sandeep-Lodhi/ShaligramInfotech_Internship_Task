using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.DbContext;
using Test.Models.Model;

namespace Test.Helper.Helper
{
    public class OrderHelper
    {
        public static order GetOrder(OrderModel orderdetails)
        {
            using (Kirtan_test_375Entities dbContext = new Kirtan_test_375Entities())
            {
                var result = dbContext.sp_orderDetails().ToList();
                //var Found = result.Find(x => x.productId == orderdetails.ProductId);
                //int price = (int)Found.itemprice;
                order OrderData = new order()
                {
                    productId = orderdetails.ProductId,
                    quantity = orderdetails.Quantity,
                    //price = orderdetails.Price,
                    //total = orderdetails.Quantity * price,
                    userid = orderdetails.UserId
                };
                return OrderData;
            }
        }
    }
}
