//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class CouponCodeMaster
    {
        public int id { get; set; }
        public string code { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<int> limit { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}
