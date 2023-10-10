using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPractice1.Models
{
    public class Form
    {
        [Required]
        [ValidationsForKrunal]
        public string fname { get; set; }
        [Required]
        public string lname { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage ="Please Enter Valid Phone Number")]
        [Range(600000,9999999999)]
        public int phone { get; set; }
        [Required]
        public bool isChecked { get; set; }
    }
}