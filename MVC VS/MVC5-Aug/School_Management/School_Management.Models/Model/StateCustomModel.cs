using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models.Model
{
    public class StateCustomModel
    {
        public int StateId { get; set; }

        [Required(ErrorMessage = "Please Enter StateName")]
        public string StateName { get; set; }

        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please Enter CName")]
        public string CountryName { get; set; }
    }
}