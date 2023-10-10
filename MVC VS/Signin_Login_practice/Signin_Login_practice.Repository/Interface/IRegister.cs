using Signin_Login_practice.Models.DbContext;
using Signin_Login_practice.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin_Login_practice.Repository.Interface
{
    public interface IRegister
    {
        void Register(CustomRegisterModel customRegisterModel);
        List<Country> GetCountry();
        List<State> GetState(int id);
        List<City> GetCity(int id);

        Registration Login(CustomRegisterModel customRegisterModel);

        IList index();
        CustomRegisterModel Edit(int id);

        int Edit(Registration registration);

        CustomRegisterModel Details(int id);

        int Delete(int id);
    }
}
