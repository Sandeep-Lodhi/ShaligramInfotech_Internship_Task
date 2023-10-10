using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Models
{
    public class StateModel
    {
        public int id { get; set; }
        [Required]
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
