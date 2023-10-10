using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Practice_4.Model.Model
{
 public   class Login_Model
    {
         public int id { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        //[MaxLength(15, ErrorMessage = "Password cannot be longer than 15 characters.")]
        public string password { get; set; }
    }
}
