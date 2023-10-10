using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPlaceTest.Models.Models
{
    public class OrderModel
    {

        public int OrderId { get; set; }
        public string Details { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Status { get; set; }
        public Nullable<int> Cust_Id { get; set; }
    }
}
