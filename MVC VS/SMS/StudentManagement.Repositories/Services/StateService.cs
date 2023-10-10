using StudentManagement.Models.Context;
using StudentManagement.Models.Models;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Services
{
    public class StateService : IStateInterface
    {

        SP355SanjayPrajapatiEntities db = new SP355SanjayPrajapatiEntities();

        public int CreateState(StateModel stateModel)
        {
            try
            {
                if (stateModel.StateId == 0)
                {
                    if (db.State.Any(x => x.StateName.ToLower() == stateModel.StateName.ToLower()))
                    {
                        return 0;
                    }
                    db.Sp_AddEditState(null, stateModel.StateName, stateModel.CountryId);
                    return 1;
                }
                if (db.State.Where(x => x.StateName == stateModel.StateName).Count() > 1)
                {
                    return 0;
                }
                db.Sp_AddEditState(stateModel.StateId, stateModel.StateName, stateModel.CountryId);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StateModel GetStateByStateId(int StateId)
        {
            try
            {
                State state = db.State.FirstOrDefault(x => x.StateId == StateId);
                return new StateModel()
                {
                    StateId = state.StateId,
                    StateName = state.StateName,
                    CountryId = (int)state.CountryId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<State> GetStates()
        {
            try
            {
                return db.State.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
