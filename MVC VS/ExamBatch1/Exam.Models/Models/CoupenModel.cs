using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Models
{
    public class CoupenModel
    {
        public int CoupenId { get; set; }
        public string Code { get; set; }
        public bool Type { get; set; }
        public Nullable<int> FlatAmount { get; set; }
        public Nullable<int> PercentageAmount { get; set; }
        public System.DateTime Expiry { get; set; }
        public int Limit { get; set; }
        public bool IsActive { get; set; }
    }
}
