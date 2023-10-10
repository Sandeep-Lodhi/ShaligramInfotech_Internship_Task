using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDusingAJAX.Models.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter Email")]
        [EmailAddress(ErrorMessage ="Enter Email Correctly")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string password { get; set; } 
    }
}
