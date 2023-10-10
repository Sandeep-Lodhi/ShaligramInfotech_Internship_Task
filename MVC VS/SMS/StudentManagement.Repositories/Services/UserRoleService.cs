using StudentManagement.Helpers;
using StudentManagement.Models.Context;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Services
{
    public class UserRoleService : IUserRoleInterface
    {
        SP355SanjayPrajapatiEntities db = new SP355SanjayPrajapatiEntities();

        public void CreateUserRole(int userId, int roleId)
        {
            try
            {
                db.UserRole.Add(new UserRoleHelper().ReturnUserRole(userId, roleId));
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
