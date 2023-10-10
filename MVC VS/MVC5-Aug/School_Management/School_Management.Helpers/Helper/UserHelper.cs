using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Helpers.UserHelper
{
    public class UserHelper
    {
        public static User BindCustomUsertoUser(CustomUserPanel data)
        {
            User userDB = new User()
            {   
                UserId=data.UserId,
                FirstName=data.FirstName,
                LastName=data.LastName,
                Email=data.Email,
                Password=data.Password,
                RoleId= (int)data.RoleId
            };
            return userDB;
        }
        public static List<CustomUserPanel> BindCustomUserListToUserList(List<User> data)
        {
            List<CustomUserPanel> userPanel  = new List<CustomUserPanel>();
      foreach (var item in data)
            {
                CustomUserPanel UserList = new CustomUserPanel();
                UserList.UserId = item.UserId;
                UserList.FirstName = item.FirstName;
                UserList.LastName = item.LastName;
                UserList.Email = item.Email;
                UserList.Password = item.Password;
                UserList.RoleId = (Roletype)item.RoleId;
                userPanel.Add(UserList);
            }
            return userPanel;
        }

        public static CustomUserPanel EditUserRecord(User user)
        {
            CustomUserPanel customUserPanel = new CustomUserPanel();
            customUserPanel.UserId = user.UserId;
            customUserPanel.FirstName = user.FirstName;
            customUserPanel.LastName = user.LastName;
            customUserPanel.Email = user.Email;
            customUserPanel.Password = user.Password;
            customUserPanel.RoleId = (Roletype)user.RoleId;
            return customUserPanel;
        }
    }
}
