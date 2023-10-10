using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjayTest.Model.Model
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [MinLength(4,ErrorMessage ="Atleast 4 character long")]
        [DisplayName("Password")]
        public string UserPassword { get; set; }
    }
}
