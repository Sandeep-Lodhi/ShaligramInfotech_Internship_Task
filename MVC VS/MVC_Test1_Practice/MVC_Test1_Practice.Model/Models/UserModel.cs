using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Test1_Practice.Model.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min 5 character required")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UserContact { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min 5 character required")]
        public string UserPassword { get; set; }

        [Required]
        [Compare("UserPassword")]
        public string UserConfirmPassword { get; set; }
    }
}
