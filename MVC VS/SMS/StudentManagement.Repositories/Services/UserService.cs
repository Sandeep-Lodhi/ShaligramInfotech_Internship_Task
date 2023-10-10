using Newtonsoft.Json;
using StudentManagement.Helpers.Helpers;
using StudentManagement.Models;
using StudentManagement.Models.Context;
using StudentManagement.Models.Models;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Services
{
    public class UserService : IUserInterface
    {
        SP355SanjayPrajapatiEntities db = new SP355SanjayPrajapatiEntities();
        public List<UserModel> GetAllUsers()
        {

            try
            {
                return new UserHelper().ConvertUserListToUserModelList(db.User.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserModel GetLoggedUserDetail(IPrincipal User1)
        {
            try
            {
                LogUserModel LoggedUser = JsonConvert.DeserializeObject<LogUserModel>(User1.Identity.Name);

                User db_user = db.User.Where(x => x.UserEmail == LoggedUser.UserEmail).FirstOrDefault();

                return new UserModel()
                {
                    UserId = db_user.UserId,
                    UserFirstName = db_user.UserFirstName,
                    UserLastName = db_user.UserLastName,
                    UserEmail = db_user.UserEmail,
                    UserPassWord = db_user.UserPassWord,
                    UserLoginRole = db.Role.Where(x => x.RoleId == LoggedUser.UserRoleId).FirstOrDefault().RoleName,
                    UserRoleName = db_user.UserRole.Select(e => e.Role.RoleName).ToList(),
                    UserRoleId = db_user.UserRole.Select(e => e.UserRoleId).ToList(),
                    UserName = db_user.UserName
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public UserModel GetLoggedUserDetailByEmail(string userEmail)
        {
            try
            {
                User db_user = db.User.Where(x => x.UserEmail == userEmail).FirstOrDefault();

                return new UserModel()
                {
                    UserId = db_user.UserId,
                    UserFirstName = db_user.UserFirstName,
                    UserLastName = db_user.UserLastName,
                    UserEmail = db_user.UserEmail,
                    UserPassWord = db_user.UserPassWord,
                    UserRoleName = db_user.UserRole.Select(e => e.Role.RoleName).ToList(),
                    UserRoleId = db_user.UserRole.Select(e => e.UserRoleId).ToList(),
                    UserName = db_user.UserName
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
