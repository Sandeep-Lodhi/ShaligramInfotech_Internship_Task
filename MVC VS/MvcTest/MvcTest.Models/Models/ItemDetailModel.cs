using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Models.Models
{
    public class ItemDetailModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemQty { get; set; }
        public decimal ItemAmount { get; set; }
    }
}
