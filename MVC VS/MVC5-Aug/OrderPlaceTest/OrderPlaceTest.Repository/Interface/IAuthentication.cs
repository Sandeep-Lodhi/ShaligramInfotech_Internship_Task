using OrderPlaceTest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPlaceTest.Repository.Interface
{
      public  interface IAuthentication
    {
         int Signup(UserModel user);
    }
}
