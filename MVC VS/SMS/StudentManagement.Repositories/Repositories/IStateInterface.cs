using StudentManagement.Models.Context;
using StudentManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Repositories
{
    public interface IStateInterface
    {
        List<State> GetStates();
        StateModel GetStateByStateId(int StateId);
        int CreateState(StateModel  stateModel);
    }
}
