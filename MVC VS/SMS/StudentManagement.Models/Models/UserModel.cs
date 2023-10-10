using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class UserModel
    {
        [DisplayName("Id")]
        public int UserId { get; set; }

        [DisplayName("First Name")]
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please enter only alphabet")]
        public string UserFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please enter only alphabet")]
        public string UserLastName { get; set; }

        [DisplayName("User Name")]
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters long.")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid Email Address")]
        public string UserEmail { get; set; }


        [DisplayName("Password")]
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters long.")]
        public string UserPassWord { get; set; }

        [DisplayName("Confirm Password")]
        [Required]
        [Compare("UserPassWord")]
        public string UserConfirmPassWord { get; set; }

        [DisplayName("Role")]
        [Required]
        public List<int> UserRoleId { get; set; }

        public List<string> UserRoleName { get; set; }

        [DisplayName("Term And Condition")]
        [Required]
        public bool UserTermCondition { get; set; }

        public string UserLoginRole { get; set; }
    }
}