//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam.Models.DBContext
{
    using System;
    
    public partial class sp_GetOrdersByDate_Result
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AfterGST { get; set; }
        public string PromoCode { get; set; }
        public decimal PayingAmount { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public Nullable<int> CustId { get; set; }
    }
}