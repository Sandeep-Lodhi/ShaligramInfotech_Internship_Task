//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sandeep_QuizApp_Practice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class user
    {
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Usename")]
        public string Name { get; set; }



        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email :")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "RePassword")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Confirm Password doesn't match , Type again !")]
        public string RePassword { get; set; }
    }
}