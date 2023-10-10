using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please Enter LastName")]
        public string LastName { get; set; } 
        [Required(ErrorMessage ="Please Enter Contact")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Please Enter Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Please Enter Email")]
        public string Email { get; set; }               
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }     
        
        [Required(ErrorMessage ="Please Enter Repeat Password")]
        [Compare("Password",ErrorMessage ="Password Didn't Match")]
        public string RepeatPassword { get; set; }        
        public string Address { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]
        public string Gender { get; set; }
        public virtual CityModel City { get; set; }
        public virtual CountryModel Country { get; set; }
        public virtual DepartmentModel Department { get; set; }
        public virtual StateModel State { get; set; }
    }
}
