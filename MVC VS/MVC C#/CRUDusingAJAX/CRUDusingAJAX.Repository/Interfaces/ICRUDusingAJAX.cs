using CRUDusingAJAX.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDusingAJAX.Repository.Interfaces
{
    public interface ICRUDusingAJAX
    {
        bool LoginService(LoginModel data);
        int RegisterService(RegisterModel data);
        IEnumerable GetUsers();
        RegisterModel GetUserById(int id);
    }
}
