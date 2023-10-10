using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Repository.Repository
{
    public interface IUserInterface
    {
        bool SignUp(CustomUserPanel data);
        string Login(CustomUserPanel data);
        List<CustomUserPanel> GetAllUserList();

        User DeleteUserRecord(int id);

        CustomUserPanel EditUserRecord(int id);
        int UpdateUserData(CustomUserPanel customUserPanel);

        //void Save();
    }
}
