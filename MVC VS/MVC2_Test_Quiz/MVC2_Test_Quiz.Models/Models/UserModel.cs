using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC2_Test_Quiz.Models.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Name :")]
        [Required(ErrorMessage = "Your name Required")]
        [StringLength(50, ErrorMessage = "5 to 50 characters.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Display(Name ="Email :")]
        [Required(ErrorMessage = "Email address Required")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Display(Name = "Contact :")]
        [Required(ErrorMessage = " Phone number is Required")]
        [DataType(DataType.PhoneNumber)]
        public string UserContact { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter Password")]
        public string UserPassword { get; set; }

        [Required]
        [Display(Name = "Re-enter Password")]
        [Compare("UserPassword", ErrorMessage = "Please Re-enter Password Again")]
        public string ReUserPassword { get; set; }
    }
}
