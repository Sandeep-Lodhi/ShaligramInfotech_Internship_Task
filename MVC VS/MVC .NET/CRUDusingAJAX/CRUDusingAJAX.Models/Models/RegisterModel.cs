using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDusingAJAX.Models.Models
{
    public class RegisterModel
    {
        public int CustId { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        public string Name { get; set; }   
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Email Correctly")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
