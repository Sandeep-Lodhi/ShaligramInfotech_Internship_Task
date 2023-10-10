using MVC_CRUD_Sandeep.Helpers.Helpers;
using MVC_CRUD_Sandeep.Models.DbContext;
using MVC_CRUD_Sandeep.Models.Models;
using MVC_CRUD_Sandeep.Repository.Intreface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD_Sandeep.Repository.Services
{
    public class AuthServices : IAuth
    {
        SandeepTestDBEntities db = new SandeepTestDBEntities(); 

        public void SignUp(UserModel userModel)
        {
            var authHelper = AuthHelper.SignUp(userModel);
            db.User.Add(authHelper);
            db.SaveChanges();
        }

    }
}
