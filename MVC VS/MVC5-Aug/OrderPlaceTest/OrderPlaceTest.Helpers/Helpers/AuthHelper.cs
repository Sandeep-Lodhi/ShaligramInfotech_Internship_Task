using OrderPlaceTest.Models.DbContext;
using OrderPlaceTest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPlaceTest.Helpers.Helpers
{
    public class AuthHelper
    { 
         public static User Signup(UserModel user)
        {
            Sit375DBEntities db = new Sit375DBEntities();

            User data = new User();
            data.id = user.id;
            data.Name = user.Name;
            data.Email = user.Email;
            data.Contact = user.Contact;
            data.Password = user.Password;

            return data;
        }
    }
}
