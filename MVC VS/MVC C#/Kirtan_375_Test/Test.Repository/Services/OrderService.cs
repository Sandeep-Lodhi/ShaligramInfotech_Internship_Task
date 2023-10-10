using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Helper.Helper;
using Test.Models.DbContext;
using Test.Models.Model;
using Test.Repository.Repository;

namespace Test.Repository.Services
{
    public class OrderService : IOrder
    {
        public Kirtan_test_375Entities dbContext = new Kirtan_test_375Entities();
        public IEnumerable<sp_orderDetails_Result> GetOrderDetails_Results()
        {
            return dbContext.sp_orderDetails().ToList();
        }

        public void AddOrder(OrderModel orderDetails)
        {
            var OrderData = OrderHelper.GetOrder(orderDetails);
            dbContext.order.Add(OrderData);
            dbContext.SaveChanges();
        }

        public void Orderdelete(int id)
        {
            var result = dbContext.order.Find(id);
            dbContext.order.Remove(result);
            dbContext.SaveChanges();
        }

        public order GetOrderId(int id)
        {
            return dbContext.order.Find(id);
        }

        public void UpdateOrder(int id, OrderModel orderDetails)
        {
            GetOrderId(id).id = orderDetails.Id;
            GetOrderId(id).quantity = orderDetails.Quantity;
            var result = dbContext.sp_orderDetails().ToList();
            var Found = result.Find(x => x.id == id);
            Found.total = orderDetails.Quantity * Found.itemprice;
            GetOrderId(id).total = Found.total;
            dbContext.SaveChanges();
        }
    }
}
