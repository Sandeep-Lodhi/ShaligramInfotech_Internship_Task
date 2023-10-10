using StudentManagement.Models.Context;
using StudentManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Repositories
{
    public interface IStandardInterface
    {
        List<StandardModel> GetStandardList();

        List<SubjectModel> GetSubjectByStandardId(int StandardId);

        List<Sp_GetTeacherBySubjectId_Result> GetTeacherBySubjectId(string SubjectId);

        List<Sp_GetStateByCountry_Result> GetStateByCountryId(int CountryId);

        List<Sp_GetCityByStateId_Result> GetCityByStateId(int StateId);
    }
}
