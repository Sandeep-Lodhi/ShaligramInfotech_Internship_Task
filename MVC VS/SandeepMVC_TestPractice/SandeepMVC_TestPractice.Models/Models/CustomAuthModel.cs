using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SandeepMVC_TestPractice.Models.Models
{
    public class CustomAuthModel
    {
        [Key]
        public int id { get; set; }

       
        [Required(ErrorMessage = "Enter First Name!")]
        [Display(Name = "Enter First Name :")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Username Length Must Be Max 20 & Min 3")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name!")]
        [Display(Name = "Enter Last Name ;")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Username Length Must Be Max 20 & Min 3")]
        public string LastName { get; set; }


        [Display(Name = " Email Id:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter The Email Address !")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter The Password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
       // [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
       // [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter The Re-Password !")]
        [Display(Name = "Confirm Password :")]
        [DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [Display(Name ="Date Of Birth :")]
        public Nullable<System.DateTime> DOB { get; set; }


        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300)]
        [Display(Name ="Enter Address :")]
        public string Address { get; set; }

        [Required]
        [Display(Name ="Country Name :")]
        public Nullable<int> CountryId { get; set; }

        [Required]
        [Display(Name = "State Name :")]
        public Nullable<int> StateId { get; set; }

        [Required]
        [Display(Name = "City Name :")]
        public Nullable<int> CityId { get; set; }

      
        public string ProfilePic { get; set; }

      
        public string AttachmentDoc { get; set; }
   

        [Display(Name ="Choose Gender :")]
        [Required(ErrorMessage = "Please Provide Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name ="Hobbies :")]
        public string Hobbies { get; set; }
        [Required]
        [Display(Name = " Profile :")]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        [Display(Name = "Upload Documents :")]
        public HttpPostedFileBase Document { get; set; }
    }
}
