using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Models
{
    public class CityModel
    {
        public int id { get; set; }
        [Required]
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }

    }
}
