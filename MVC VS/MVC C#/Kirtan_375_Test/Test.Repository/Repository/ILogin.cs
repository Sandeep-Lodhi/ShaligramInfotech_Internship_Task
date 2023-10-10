using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.DbContext;
using Test.Models.Model;

namespace Test.Repository.Repository
{
    public interface ILogin
    {
        user GetUserDetail(LoginModel user);
    }
}
