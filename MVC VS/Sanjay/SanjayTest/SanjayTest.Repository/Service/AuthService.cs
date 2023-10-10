using SanjayTest.Model.Context;
using SanjayTest.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjayTest.Repository.Service
{
    public class AuthService : IAuthInterface
    {

        SP355_SanjayMvcTestEntities db = new SP355_SanjayMvcTestEntities();

        public int UserLogin(string UserName, string UserPassword)
        {
            try
            {
                List<User> userList = db.User.ToList();
                if (userList.Any(x => x.UserName == UserName))
                {
                    if (userList.Any(x => x.UserName == UserName && x.UserPassword == UserPassword))
                    {
                        return 1;   // success
                    }
                    return 2;   // wrong password
                }
                return 0;   //user not found
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetLoggedUser(string UserName)
        {
            return db.User.FirstOrDefault(x => x.UserName == UserName);

        }
    }
}
