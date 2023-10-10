using Newtonsoft.Json;
using StudentManagement.Helpers.Helpers;
using StudentManagement.Models;
using StudentManagement.Models.Context;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagement.Repositories.Services
{
    public class AuthService : IAuthInterface
    {
        SP355SanjayPrajapatiEntities db = new SP355SanjayPrajapatiEntities();

        public int CreateNewUser(UserModel user)
        {
            try
            {
                if (db.User.Any(x => x.UserEmail == user.UserEmail || x.UserName == user.UserName))
                {
                    return user.UserId;
                }
                else
                {
                    User userId = db.User.Add(new UserHelper().ConvertUserModelToUser(user));
                    db.SaveChanges();
                    return userId.UserId;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        

        public int UserLogin(UserModel user)
        {
            try
            {
                int roleId = user.UserRoleId[0];
                if (db.User.Any(x => x.UserEmail == user.UserEmail))
                {
                    if (db.User.Any(x => x.UserEmail == user.UserEmail && x.UserPassWord == user.UserPassWord))
                    {
                        if (db.User.Any(x => x.UserEmail == user.UserEmail && x.UserPassWord == user.UserPassWord && x.UserRole.Any(n => n.RoleId == roleId)))
                        {
                            return 1; // Login Success
                        }
                        return 2; // Role Does Not Assigned
                    }
                    return 3; // Incorrect password
                }
                return 0; //Email does not exist
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        List<Role> IAuthInterface.GetAllRole()
        {
            try
            {
                return db.Role.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
