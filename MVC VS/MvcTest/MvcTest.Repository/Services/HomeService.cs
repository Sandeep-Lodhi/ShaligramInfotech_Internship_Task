using MvcTest.Models.Context;
using MvcTest.Models.Models;
using MvcTest.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Repository.Services
{
    public class HomeService : IHomeInterface
    {
        SP_355MvcTestEntities db = new SP_355MvcTestEntities();

        public SP_GetAllItems_Result GetItemById(int ItemId)
        {
            try
            {
                return db.SP_GetAllItems().FirstOrDefault(x => x.ItemId == ItemId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_GetAllItems_Result> GetItemList()
        {
            try
            {
                return db.SP_GetAllItems().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SP_GetAllCoupons_Result> GetCoupenByCode(string Code)
        {
            try
            {
                return db.SP_GetAllCoupons().Where(x => x.Code == Code).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  void CreateOrder(List<ItemDetailModel> itemDetails, OrdersModel ordersModel)
        {
            try
            {
                var i = db.SP_CreateOrder(ordersModel.TotalItems, ordersModel.TotalAmount, ordersModel.Cgst, ordersModel.Sgst, ordersModel.PaybleAmount, ordersModel.NetPaybleAmount, ordersModel.PromoCode, ordersModel.UserId);
                string id = i.SingleOrDefault().ToString();
                int OrderId = Convert.ToInt32(id);
                itemDetails.ForEach(x =>
                {
                    db.SP_CreateItemDetail(x.ItemName, x.ItemQty, x.ItemAmount, OrderId);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Orders> GetOrdersList(int UserId)
        {
            try
            {
                return db.Orders.Where(x=>x.UserId == UserId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemDetails> GetItemList(int OrderId)
        {
            try
            {
                return db.ItemDetails.Where(x => x.OrderId == OrderId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
