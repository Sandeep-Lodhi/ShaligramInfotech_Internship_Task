using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.Model
{
    public class CoupenModel
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public int Limit { get; set; }
        public bool IsActive { get; set; }
    }
}
