using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^([A-Za-z])+$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^([A-Za-z])+$", ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^([0-9])+$", ErrorMessage = "Invalid Last Name")]
        [MaxLength(10, ErrorMessage = "Contact Number Must Be Of 10 Character")]
        [MinLength(6, ErrorMessage = "Contact Number Must Be Of 6 Character")]
        public string Contact { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }                      
        [Required]
        [MinLength(6,ErrorMessage = "Password Must Be Of 6 Character")]
        public string Password { get; set; }                   
        [Required] 
        [Compare("Password",ErrorMessage ="Password Should Be Match")]
        public string RepeatPassword { get; set; }                   
        [Required]
        public string Address { get; set; }      
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }   
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }       
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select State")]
        public int StateId { get; set; }         
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select City")]
        public int CityId { get; set; }              
        [Required]
        public string Gender { get; set; }      
        public virtual DepartmentModel Department { get; set; }
        public virtual CountryModel Country { get; set; }    
        public virtual StateModel State { get; set; }    
        public virtual CityModel City { get; set; }  
    }           
}
