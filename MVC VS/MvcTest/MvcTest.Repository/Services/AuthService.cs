using MvcTest.Models.Context;
using MvcTest.Models.Models;
using MvcTest.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Repository.Services
{
    public class AuthService : IAuthInterface
    {
        SP_355MvcTestEntities db = new SP_355MvcTestEntities();


        public int UserSignUp(UserModel userModel)
        {
            try
            {
                if (db.User.Any(x => x.UserEmail == userModel.UserEmail || x.UserName == userModel.UserName))
                {
                    return 0;
                }
                db.SP_AddEditUser(null, userModel.UserName, userModel.UserEmail, userModel.UserContact, userModel.UserPassword);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UserLogin(string UserEmail, string UserPassword)
        {
            try
            {
                List<User> userList = db.User.ToList();
                if (userList.Any(x => x.UserEmail == UserEmail))
                {
                    if (userList.Any(x => x.UserEmail == UserEmail && x.UserPassword == UserPassword))
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

        public User GetLoggedUser(string UserEmail)
        {
            return db.User.FirstOrDefault(x => x.UserEmail == UserEmail);
        }
    }
}
