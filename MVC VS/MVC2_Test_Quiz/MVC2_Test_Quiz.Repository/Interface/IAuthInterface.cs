using MVC2_Test_Quiz.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC2_Test_Quiz.Repository.Interface
{
    public interface IAuthInterface
    {
        int UserLogin(string UserName, string UserPassword);

        User GetLoggedUser(string UserName);
    }
}
