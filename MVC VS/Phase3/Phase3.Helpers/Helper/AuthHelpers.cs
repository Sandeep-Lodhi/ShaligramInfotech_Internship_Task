using Phase3.Models.DbContext;
using Phase3.Models.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase3.Helpers.Helper
{
    public class AuthHelpers
    {
        public static User Signup(AuthModel data)  // custom model data in converting to db model
        {
            User result = new User
            {
                UserName=data.UserName,
                Email=data.Email,
                Password=data.Password
            };
            return result;
        }

        public static AuthModel Edit(User user)
        {
            AuthModel authModel = new AuthModel();

            if (authModel != null)
            {
                authModel.Id = user.Id;
                authModel.UserName = user.UserName;
                authModel.Email = user.Email;
                authModel.Password = user.Password;
            }
            return authModel;
        }

        public static int Details(int Id)
        {
           
            return Details(Id);
        }

        public static int Delete(int Id)
        {
            return Delete(Id);
        }

    }
}
