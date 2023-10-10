using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.Models
{
    public class StateModel
    {
        public int StateId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Min 3 letters required")]
        public string StateName { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
