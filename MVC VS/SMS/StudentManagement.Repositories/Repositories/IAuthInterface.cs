using StudentManagement.Models;
using StudentManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagement.Repositories.Repositories
{

    public interface IAuthInterface
    {
        List<Role> GetAllRole();

        int CreateNewUser(UserModel user);

        int UserLogin(UserModel user);
    }
}
