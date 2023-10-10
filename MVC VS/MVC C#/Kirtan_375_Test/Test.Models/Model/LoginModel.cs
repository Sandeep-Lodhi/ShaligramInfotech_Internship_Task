using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.Model
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Email!")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Please Enter Password!")]
        public string Password {get; set; }
    }
}
