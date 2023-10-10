using MVC_Test1_Practice.Model.DbContext;
using MVC_Test1_Practice.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Test1_Practice.Repository.Interface
{
   public interface IAuthInterface
    {
        int UserSignUp(UserModel userModel);

        int UserLogin(string UserEmail, string UserPassword);

        User GetLoggedUser(string UserEmail);
    }
}
