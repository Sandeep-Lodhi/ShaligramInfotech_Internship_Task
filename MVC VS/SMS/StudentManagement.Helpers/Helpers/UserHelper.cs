using StudentManagement.Models;
using StudentManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helpers.Helpers
{
    public class UserHelper
    {
        public User ConvertUserModelToUser(UserModel userModel)
        {
            return new User()
            {
                UserFirstName = userModel.UserFirstName,
                UserLastName = userModel.UserLastName,
                UserEmail = userModel.UserEmail,
                UserId = userModel.UserId,
                UserName = userModel.UserName,
                UserPassWord = userModel.UserPassWord
            };
        }


        public List<UserModel> ConvertUserListToUserModelList(List<User> userList)
        {
            List<UserModel> userModelList = new List<UserModel>();

            foreach (User user in userList)
            {
                userModelList.Add(new UserModel()
                {
                    UserId = user.UserId,
                    UserFirstName = user.UserFirstName,
                    UserLastName = user.UserLastName,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    UserPassWord = user.UserPassWord,
                    UserRoleName = user.UserRole.Select(e => e.Role.RoleName).ToList(),
                    UserRoleId = user.UserRole.Select(e => e.UserRoleId).ToList()
                });
            }
            return userModelList;
        }
    }
}
