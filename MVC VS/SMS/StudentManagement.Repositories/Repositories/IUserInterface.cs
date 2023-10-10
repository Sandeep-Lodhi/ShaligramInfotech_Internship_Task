using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Repositories
{
    public interface IUserInterface
    {
        List<UserModel> GetAllUsers();

        UserModel GetLoggedUserDetail(IPrincipal User);

        UserModel GetLoggedUserDetailByEmail(string userEmail);
    }
}
