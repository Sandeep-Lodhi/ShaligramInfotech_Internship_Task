using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase3.Models.Model
{
    class EditModel
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Usename")]
        public string UsernameUs { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PasswordUs { get; set; }
    }
}
