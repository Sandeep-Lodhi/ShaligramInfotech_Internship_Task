using StudentManagement.Helpers.Helpers;
using StudentManagement.Models;
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
    public class StandardService : IStandardInterface
    {
        SP355SanjayPrajapatiEntities db = new SP355SanjayPrajapatiEntities();

        public List<StandardModel> GetStandardList()
        {
            try
            {
                return new StandardHelper().ConvertStandardToStandardModelList(db.Standard.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SubjectModel> GetSubjectByStandardId(int StandardId)
        {
            List<SubjectModel> subjectModelList = new List<SubjectModel>();

            foreach (StandardSubject standardSubject in db.StandardSubject.Where(x => x.StandardId == StandardId).ToList())
            {
                subjectModelList.Add(
                    new SubjectModel()
                    {
                        SubjectId = (int)standardSubject.SubjectId,
                        SubjectName = standardSubject.Subject.SubjectName
                    }
                    );
            }
            return subjectModelList;
        }

        public List<Sp_GetTeacherBySubjectId_Result> GetTeacherBySubjectId(string SubjectId)
        {
            try
            {
                return db.Sp_GetTeacherBySubjectId(SubjectId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sp_GetStateByCountry_Result> GetStateByCountryId(int CountryId)
        {
            try
            {
                return db.Sp_GetStateByCountry(CountryId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sp_GetCityByStateId_Result> GetCityByStateId(int StateId)
        {
            try
            {
                return db.Sp_GetCityByStateId(StateId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
