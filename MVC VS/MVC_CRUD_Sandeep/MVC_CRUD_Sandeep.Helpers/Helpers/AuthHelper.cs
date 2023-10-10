using MVC_CRUD_Sandeep.Models.DbContext;
using MVC_CRUD_Sandeep.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD_Sandeep.Helpers.Helpers
{
    public  class AuthHelper
    {
        public static User SignUp(UserModel userModel)
        {
            User data =new  User();

            data.UserId = userModel.UserId;
            data.UserName = userModel.UserName;
            data.UserEmail = userModel.UserEmail;
            data.UserContact = userModel.UserContact;
            data.UserPassword = userModel.UserPassword;

            return data;
        }
    }
}
