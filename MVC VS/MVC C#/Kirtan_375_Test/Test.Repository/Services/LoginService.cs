using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.DbContext;
using Test.Models.Model;
using Test.Repository.Repository;

namespace Test.Repository.Services
{
    public class LoginService : ILogin
    {
        Kirtan_test_375Entities dbContext = new Kirtan_test_375Entities();
        public user GetUserDetail(LoginModel user)
        {
            try
            {
                var userList = dbContext.user.ToList();
                var result = userList.Find(x => x.email == user.Email);
                if (result != null)
                {
                    if (result.password == user.Password)
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
