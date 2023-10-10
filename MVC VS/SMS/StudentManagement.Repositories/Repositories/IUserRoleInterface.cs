using StudentManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Repositories
{
    public interface IUserRoleInterface
    {
        void CreateUserRole(int userId, int roleId);
    }
}
