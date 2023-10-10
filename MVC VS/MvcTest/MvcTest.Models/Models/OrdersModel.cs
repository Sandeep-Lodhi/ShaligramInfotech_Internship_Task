using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Models.Models
{
    public class OrdersModel
    {
        public int OrderId { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Cgst { get; set; }
        public decimal Sgst { get; set; }
        public decimal PaybleAmount { get; set; }
        public decimal NetPaybleAmount { get; set; }
        public string  PromoCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }

    }
}
