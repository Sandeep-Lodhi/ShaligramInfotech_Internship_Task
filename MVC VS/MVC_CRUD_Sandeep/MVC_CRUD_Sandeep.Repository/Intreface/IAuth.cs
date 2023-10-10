using MVC_CRUD_Sandeep.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD_Sandeep.Repository.Intreface
{
    public  interface IAuth
    {
        void SignUp(UserModel userModel);
        
    }
}
