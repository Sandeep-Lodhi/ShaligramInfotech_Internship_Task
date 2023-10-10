using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Helpers.UserHelper
{
    public class StateHelper
    {
        //public static State customstateToDBstate(StateCustomModel data)
        //{
        //    State statetdata = new State()
        //    {
        //        StateId = data.StateId,
        //        StateName = data.StateName,
        //        CountryId = data.CountryId
        //    };
        //    return statetdata;
        //}

        //public static List<StateCustomModel> DBlistToCustomlist(List<State> data)
        //{
        //    List<StateCustomModel> customstate = new List<StateCustomModel>();

        //    foreach (var item in data)
        //    {
        //        StateCustomModel statelist = new StateCustomModel();
        //        statelist.StateId = item.StateId;
        //        statelist.StateName = item.StateName;
        //        statelist.CountryId = (int)item.CountryId;
        //        customstate.Add(statelist);
        //    }
        //    return customstate;
        //}

        public static StateCustomModel customStateToDBstate(State data) 
        {
            try
            {
                StateCustomModel statedata = new StateCustomModel();
                statedata.StateId = data.StateId;
                statedata.StateName = data.StateName;
                statedata.CountryId = (int)data.CountryId;
                return statedata;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
