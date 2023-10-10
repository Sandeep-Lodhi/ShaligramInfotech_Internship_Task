using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // used for display attribute


namespace MVCPractice1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="Please Enter Your Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsEmployee { get; set; }
        [Display(Name = "Please Enter Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string email { get; set; }
    }
}