//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Test1_Practice.Model.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class CouponCodeMaster
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public Nullable<int> FlatAmount { get; set; }
        public Nullable<int> Percentage { get; set; }
        public Nullable<System.DateTime> Expirydate { get; set; }
        public Nullable<int> UsageLimit { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}