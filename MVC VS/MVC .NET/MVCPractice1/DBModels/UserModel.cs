using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DBModels
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }      
        [Required]
        public string Email { get; set; }     
        [Required]
        public string Contact { get; set; }   
        [Required]
        public string Address { get; set; }   
        [Required]
        public int? UserTypeId { get; set; }  
        [Required]
        public int? CountryId { get; set; }   
        [Required]
        public int? StateyId { get; set; }    
        [Required]
        public int? CityId { get; set; }
        
        public virtual UserTypeModel UserType { get; set; } 
        
        public virtual CountryModel Country { get; set; }
        
        public virtual StateModel State { get; set; }
        
        public virtual CityModel City { get; set; }
    }
}
