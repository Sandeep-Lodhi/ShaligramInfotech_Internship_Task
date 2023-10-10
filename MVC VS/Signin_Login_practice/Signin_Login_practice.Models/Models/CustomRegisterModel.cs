using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Signin_Login_practice.Models.Models
{
    public class CustomRegisterModel
    {
        [Key]
        public int id { get; set; }

  
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        [Display(Name ="First Name :")]
        public string FirstName { get; set; }
    
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        [Display(Name ="Last Name :")]
        public string LastName { get; set; }
   
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
       // [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        [Display(Name ="Email :")]
        [EmailAddress]
        public string Email { get; set; }

       
        [Required(ErrorMessage = "Enter The Password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter The Re-Password !")]
        [Display(Name = "Confirm Password :")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage ="Date of Birth is required!")]
        [Display(Name = "Data of Birth :")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required(ErrorMessage ="Address is required!")]
        [Display(Name = "Address :")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Country Name :")]
        public Nullable<int> CountryId { get; set; }
        [Required]
        [Display(Name = "State Name :")]
        public Nullable<int> StateId { get; set; }
        [Required]
        [Display(Name = "City Name :")]
        public Nullable<int> CityId { get; set; }
        public string ProfilePic { get; set; }
        public string AttachmentDoc { get; set; }
 

        [Required(ErrorMessage = "Please Provide Gender")]
        [Display(Name = "Gender :")]
        public string Gender { get; set; }

        [Required]
        [Display(Name ="Hobbies :")]
        public string Hobbies { get; set; }

        [Required]
        [Display(Name ="Add Profile :")]
        public HttpPostedFileBase Profile { get; set; }
        [Required]
        [Display(Name ="Attach Documents :")]
        public HttpPostedFileBase Documents { get; set; }

    }
}
