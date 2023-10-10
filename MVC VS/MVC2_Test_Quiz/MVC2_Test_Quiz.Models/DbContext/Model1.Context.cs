﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC2_Test_Quiz.Models.DbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SandeepTestDBEntities : DbContext
    {
        public SandeepTestDBEntities()
            : base("name=SandeepTestDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<User> User { get; set; }
    
        public virtual int SP_AddEditUser(Nullable<int> userId, string userName, string userEmail, string userContact, string userPassword)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var userEmailParameter = userEmail != null ?
                new ObjectParameter("UserEmail", userEmail) :
                new ObjectParameter("UserEmail", typeof(string));
    
            var userContactParameter = userContact != null ?
                new ObjectParameter("UserContact", userContact) :
                new ObjectParameter("UserContact", typeof(string));
    
            var userPasswordParameter = userPassword != null ?
                new ObjectParameter("UserPassword", userPassword) :
                new ObjectParameter("UserPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_AddEditUser", userIdParameter, userNameParameter, userEmailParameter, userContactParameter, userPasswordParameter);
        }
    
        public virtual int SP_CreateItemDetail(string itemName, Nullable<int> itemQty, Nullable<decimal> itemAmount, Nullable<int> orderId)
        {
            var itemNameParameter = itemName != null ?
                new ObjectParameter("ItemName", itemName) :
                new ObjectParameter("ItemName", typeof(string));
    
            var itemQtyParameter = itemQty.HasValue ?
                new ObjectParameter("ItemQty", itemQty) :
                new ObjectParameter("ItemQty", typeof(int));
    
            var itemAmountParameter = itemAmount.HasValue ?
                new ObjectParameter("ItemAmount", itemAmount) :
                new ObjectParameter("ItemAmount", typeof(decimal));
    
            var orderIdParameter = orderId.HasValue ?
                new ObjectParameter("OrderId", orderId) :
                new ObjectParameter("OrderId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CreateItemDetail", itemNameParameter, itemQtyParameter, itemAmountParameter, orderIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_CreateOrder(Nullable<int> totalItems, Nullable<decimal> totalAmount, Nullable<decimal> cgst, Nullable<decimal> sgst, Nullable<decimal> paybleAmount, Nullable<decimal> netPaybleAmount, string promoCode, Nullable<int> userId)
        {
            var totalItemsParameter = totalItems.HasValue ?
                new ObjectParameter("TotalItems", totalItems) :
                new ObjectParameter("TotalItems", typeof(int));
    
            var totalAmountParameter = totalAmount.HasValue ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
    
            var cgstParameter = cgst.HasValue ?
                new ObjectParameter("Cgst", cgst) :
                new ObjectParameter("Cgst", typeof(decimal));
    
            var sgstParameter = sgst.HasValue ?
                new ObjectParameter("Sgst", sgst) :
                new ObjectParameter("Sgst", typeof(decimal));
    
            var paybleAmountParameter = paybleAmount.HasValue ?
                new ObjectParameter("PaybleAmount", paybleAmount) :
                new ObjectParameter("PaybleAmount", typeof(decimal));
    
            var netPaybleAmountParameter = netPaybleAmount.HasValue ?
                new ObjectParameter("NetPaybleAmount", netPaybleAmount) :
                new ObjectParameter("NetPaybleAmount", typeof(decimal));
    
            var promoCodeParameter = promoCode != null ?
                new ObjectParameter("PromoCode", promoCode) :
                new ObjectParameter("PromoCode", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_CreateOrder", totalItemsParameter, totalAmountParameter, cgstParameter, sgstParameter, paybleAmountParameter, netPaybleAmountParameter, promoCodeParameter, userIdParameter);
        }
    
        public virtual ObjectResult<SP_GetAllCoupons_Result> SP_GetAllCoupons()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAllCoupons_Result>("SP_GetAllCoupons");
        }
    
        public virtual ObjectResult<SP_GetAllItems_Result> SP_GetAllItems()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetAllItems_Result>("SP_GetAllItems");
        }
    
        public virtual ObjectResult<SP_GetQuestionsAndAnswers_Result> SP_GetQuestionsAndAnswers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GetQuestionsAndAnswers_Result>("SP_GetQuestionsAndAnswers");
        }
    }
}
