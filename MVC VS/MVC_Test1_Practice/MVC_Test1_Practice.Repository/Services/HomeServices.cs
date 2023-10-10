using MVC_Test1_Practice.Model.DbContext;
using MVC_Test1_Practice.Model.Models;
using MVC_Test1_Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Test1_Practice.Repository.Services
{

 
    public class HomeServices : IHomeInterface
    {
        SandeepTestDBEntities db = new SandeepTestDBEntities();

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


        public void CreateOrder(List<ItemDetailModel> itemDetails, OrderModel ordersModel)
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
                return db.Orders.Where(x => x.UserId == UserId).ToList();
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
    }
}



