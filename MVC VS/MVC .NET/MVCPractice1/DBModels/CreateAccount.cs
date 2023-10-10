using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DBModels
{
    public class CreateAccount
    {
        public int id { get; set; }
        [Required]
        public string fname { get; set; }             
        [Required]     
        public string lname { get; set; }             
        [Required]
        [EmailAddress]
        public string email { get; set; }             
        [Required]
        public string contact { get; set; }           
        [Required]
        public string address { get; set; }           
        [Required]
        public string password { get; set; }
        [Required]
        public string UserName { get; set; }               
        [Required]
        public string repeatpassword { get; set; }
        [Required]
        public virtual CountryModel Country { get; set; } 
        [Required]
        public virtual StateModel State { get; set; }
        [Required]
        public virtual CityModel City { get; set; } 
        
    }
}
