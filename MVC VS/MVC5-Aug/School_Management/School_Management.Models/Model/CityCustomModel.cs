using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Models.Model
{
    public class CityCustomModel
    {
        [Required(ErrorMessage = "Please Enter CityId")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please Enter CityName")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please Enter StateId")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Please Enter CountryId")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please Enter StateName")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Enter CountryName")]
        public string CountryName { get; set; }
    }
}
