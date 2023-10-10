using School_Management.Helpers.UserHelper;
using School_Management.Models.Context;
using School_Management.Models.Model;
using School_Management.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Repository.Services
{
    public class StateServices : IStateInterface
    {
        Ram_School_Management_352Entities dbContext = new Ram_School_Management_352Entities();
        //public string AddState(StateCustomModel CustomState)
        //{
        //    State statedata = StateHelper.customstateToDBstate(CustomState);

        //    if (statedata != null)
        //    {
        //        dbContext.State.Add(statedata);
        //        dbContext.SaveChanges();
        //        return "pass";
        //    }
        //    else {
        //        return "fail";
        //    }
        //}

        public string AddState(StateCustomModel CustomState)
        {
            try
            {
                var stateexist = dbContext.State.Where(x => x.StateName.Equals(CustomState.StateName)).FirstOrDefault();
                if (stateexist != null)
                {
                    return "fail";
                }
                else
                {
                    dbContext.sp_stateadd_edit(null, CustomState.StateName, CustomState.CountryId);
                    dbContext.SaveChanges();
                    return "pass";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Country> CountryList()
        {
            List<Country> country = new List<Country>();
            country = dbContext.Country.ToList();
            return country;         
        }

        //public List<StateCustomModel> GetStatelist()
        //{
        //    List<State> StateList = new List<State>();

        //    List<StateCustomModel> CustomStateList = new List<StateCustomModel>();

        //    StateList = dbContext.State.ToList();

        //    CustomStateList = StateHelper.DBlistToCustomlist(StateList);

        //    if(CustomStateList != null && CustomStateList.Count > 0)
        //    {
        //        return CustomStateList;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public List<StateList_Result> GetStatelist()
        {
            List<StateList_Result> StateList = dbContext.StateList().ToList();

            if (StateList != null && StateList.Count > 0)
            {
                return StateList;
            }
            else
            {
                return null;
            }
        }
        public State DeleteStateRecord(int id)
        {
            var DeleteState = dbContext.State.Find(id);
            if (DeleteState != null)
            {
                var Delete = dbContext.State.Remove(DeleteState);
                dbContext.SaveChanges();
                return Delete;
            }
            else
            { 
            return null;
            }
        }

        public StateCustomModel GetState(int id)
        {
            State state = dbContext.State.Find(id);
            StateCustomModel statemodel = StateHelper.customStateToDBstate(state);
            return statemodel;
        }

        public string EditState(StateCustomModel statedata)
        {
            var stateexist = dbContext.State.Where(x => x.StateId.Equals(statedata.StateId)).FirstOrDefault();
            if (stateexist != null)
            {
                dbContext.sp_stateadd_edit(statedata.StateId, statedata.StateName, statedata.CountryId);
                dbContext.SaveChanges();
                return "pass";
            }
            else
            {
                return "fail";
            }
        }

        public List<State> GetStatesByCountryId(int id)
        {
            List<State> states = dbContext.State.Where(x => x.CountryId == id).ToList();
            return states;
        }
    }
}
