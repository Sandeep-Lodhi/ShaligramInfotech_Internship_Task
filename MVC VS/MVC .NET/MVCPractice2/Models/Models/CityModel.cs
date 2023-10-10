using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CityModel
    {
        public int id { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }

        public virtual CountryModel Country { get; set; }
        public virtual StateModel State { get; set; }
    }
}
