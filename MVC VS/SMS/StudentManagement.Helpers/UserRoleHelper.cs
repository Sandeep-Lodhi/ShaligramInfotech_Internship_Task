using StudentManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helpers
{
    public class UserRoleHelper
    {
        public UserRole ReturnUserRole(int userId,int roleId)
        {
            return new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
        }
    }
}
