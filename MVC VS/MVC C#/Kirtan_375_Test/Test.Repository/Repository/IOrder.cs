using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.DbContext;
using Test.Models.Model;

namespace Test.Repository.Repository
{
    public interface IOrder
    {
        IEnumerable<sp_orderDetails_Result> GetOrderDetails_Results();

        void AddOrder(OrderModel orderDetails);

        void Orderdelete(int id);

        order GetOrderId(int id);

        void UpdateOrder(int id, OrderModel orderDetails);
    }
}
