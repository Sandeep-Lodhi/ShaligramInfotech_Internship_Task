using SandeepMVC3_Test.Models.DbContext;
using SandeepMVC3_Test.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandeepMVC3_Test.Repository.Interface
{
   public interface IAuth
    {
        void SignUp(RegistrationModel registrationModel);

   
        Registration Login(RegistrationModel registrationModel);


        List<Country> GetCountry();
        List<State> GetState(int id);

        List<City> GetCity(int id);

        RegistrationModel ShowUser(int id);

        IList index();

        RegistrationModel Edit(int id);

        int Edit(Registration registration);

        int Delete(int id);
        Registration GetUserById(int id);
    }
}
