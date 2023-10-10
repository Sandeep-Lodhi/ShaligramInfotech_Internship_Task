using MvcTest.Models.Context;
using MvcTest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Repository.Repositories
{
    public interface IAuthInterface
    {
        int UserSignUp(UserModel userModel);

        int UserLogin(string UserEmail,string UserPassword);

        User GetLoggedUser(string UserEmail);
    }
}
