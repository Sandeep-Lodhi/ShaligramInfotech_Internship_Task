using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Practice_4.Reposatory.Inserface
{
   public interface IUserInterface1
    {
        void Adddata(IUserInterface1 user);
        bool DeleteUser(int id);

        void Edit(IUserInterface1 user);
    }

}
