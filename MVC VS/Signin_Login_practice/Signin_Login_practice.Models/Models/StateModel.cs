using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin_Login_practice.Models.Models
{
    public class StateModel
    {
        public int id { get; set; }
        public string StateName { get; set; }
        public Nullable<int> Cid { get; set; }
        public virtual Countrymodel Country { get; set; }
    }
}
