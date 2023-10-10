using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Models
{
    public class CountryModel
    {
        public int id { get; set; }
        [Required]
        public string CountryName { get; set; }
    }
}
