using SandeepMVC_TestPractice.Models.DbContext;
using SandeepMVC_TestPractice.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandeepMVC_TestPractice.Repository.Interface
{
    public interface IAuth
    {
        void SignUp(CustomAuthModel customAuthModel);

        //IList index(string option, string search, int? pageNumber, string sort);
        IList index();
        List<Country> GetCountry();
        List<State> GetState( int id);

        List<City> GetCity(int id);

        Registration Login(CustomAuthModel customAuthModel);

        CustomAuthModel ShowUser(int id);

        CustomAuthModel Edit(int id);
        int Edit(Registration registration);

       //bool UpdateUser(int id, Registration registration);

        int Delete(int id);
        Registration GetUserById(int id);

    }

  
}
