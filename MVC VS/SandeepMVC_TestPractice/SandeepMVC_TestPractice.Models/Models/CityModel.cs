using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandeepMVC_TestPractice.Models.Models
{
    public class CityModel
    {
        public int id { get; set; }
        public string CityName { get; set; }
        public Nullable<int> Cid { get; set; }
        public Nullable<int> Sid { get; set; }
        public virtual CountryModel Country { get; set; }
        public virtual StateModel State { get; set; }
      
    }
}
