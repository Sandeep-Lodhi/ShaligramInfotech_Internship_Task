using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase3.Models.Model
{
    public class AuthModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Usename")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "RePassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match , Type again !")]
        public string RePassword { get; set; }
    }


}
