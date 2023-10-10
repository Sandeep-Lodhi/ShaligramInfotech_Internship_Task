using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Practice_4.Model.Model
{
   public class User_Model
    {
          
        [Key]
        public int id { get; set; }

        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Firstname { get; set; }


        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Lastname { get; set; }

        [Display(Name = "Age")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }


        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string MobileNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        //[MaxLength(15, ErrorMessage = "Password cannot be longer than 15 characters.")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]


        [Compare("password", ErrorMessage = "Confirm  Password doesn't match, Try again !")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        public string ConfirmPassword { get; set; }
    
}
}
