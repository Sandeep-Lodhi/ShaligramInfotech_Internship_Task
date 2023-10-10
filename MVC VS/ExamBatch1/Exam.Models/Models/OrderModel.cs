using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Models
{
    public class OrderModel
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
        public virtual CustomerModel Customer { get; set; }
    }
}
