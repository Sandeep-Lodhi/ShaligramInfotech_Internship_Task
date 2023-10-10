using Phase3.Models.DbContext;
using Phase3.Models.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase3.Repositaries.Interface
{
   public interface IAuthInterface
    {
        int Signup(AuthModel data);

         IList Index();

        AuthModel Edit(int Id);
         int Edit(User user);

        int Details(int Id);

        int Delete(int Id);

        User GetUserById(int id);


    }
}
