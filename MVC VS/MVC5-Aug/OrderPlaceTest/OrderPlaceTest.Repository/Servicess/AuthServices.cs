using OrderPlaceTest.Helpers.Helpers;
using OrderPlaceTest.Models.DbContext;
using OrderPlaceTest.Models.Models;
using OrderPlaceTest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPlaceTest.Repository.Servicess
{
   public  class AuthServices : IAuthentication
    {
        Sit375DBEntities db = new Sit375DBEntities();

        public int Signup(UserModel user)
        {

            var result = AuthHelper.Signup(user);
            if(result != null)
            {
                db.User.Add(result);
                db.SaveChanges();
                return result.id;
            }
            return 0;          
        }
    }
}
