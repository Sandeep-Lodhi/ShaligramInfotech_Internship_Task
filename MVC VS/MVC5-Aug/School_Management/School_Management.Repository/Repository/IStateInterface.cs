using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Repository.Repository
{
    public interface IStateInterface
    {
        string AddState(StateCustomModel CustomState);

        List<Country> CountryList();

        //List<StateCustomModel> GetStatelist();
        List<StateList_Result> GetStatelist();

        StateCustomModel GetState(int id);
        string EditState (StateCustomModel state);

        State DeleteStateRecord(int id);

        List<State> GetStatesByCountryId(int id);



    }
}
