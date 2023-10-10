//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Required(ErrorMessage = "This Field is Required ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Required ")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="This Field is Required ")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Field is Required ")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirm PassWord")]
        [Required(ErrorMessage = "This Field is Required ")]
        public string ConfirnPassword { get; set; }
    }
}
