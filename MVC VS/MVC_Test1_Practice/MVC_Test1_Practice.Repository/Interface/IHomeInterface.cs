using MVC_Test1_Practice.Model.DbContext;
using MVC_Test1_Practice.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Test1_Practice.Repository.Interface
{
    public interface IHomeInterface
    {
        List<SP_GetAllItems_Result> GetItemList();

        SP_GetAllItems_Result GetItemById(int ItemId);

        List<SP_GetAllCoupons_Result> GetCoupenByCode(string Code);

        void CreateOrder(List<ItemDetailModel> itemDetails, OrderModel ordersModel);
        List<Orders> GetOrdersList(int UserId);

        List<ItemDetails> GetItemList(int OrderId);
    }
}
