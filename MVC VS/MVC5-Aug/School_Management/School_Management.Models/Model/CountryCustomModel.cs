using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models.Model
{
    public class CountryCustomModel
    {
        [Required(ErrorMessage ="Please Enter CountryId")]
        public int CountryId { get; set; }
     
        
        [Required(ErrorMessage = "Please Enter CountryName")]
        public string CountryName { get; set; }
    }
}