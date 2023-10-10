using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.DbContext;
using Test.Models.Model;

namespace Test.Helper.Helper
{
    public class LoginHelper
    {
        public static user GetUser(LoginModel userdetails)
        {
            using (Kirtan_test_375Entities dbContext = new Kirtan_test_375Entities())
            {
                user userdata = new user()
                {
                    email = userdetails.Email,
                    password = userdetails.Password
                };
                return userdata;
            }
        }
    }
}
