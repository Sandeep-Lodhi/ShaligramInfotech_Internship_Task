using SanjayTest.Model.Context;
using SanjayTest.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjayTest.Repository.Service
{
    public class HomeService : IHomeInterface
    {

        SP355_SanjayMvcTestEntities db = new SP355_SanjayMvcTestEntities();

        public List<SP_GetQuestionsAndAnswers_Result> GetQuestionById(int QId)
        {
            try
            {
                return db.SP_GetQuestionsAndAnswers().Where(x=>x.QId==QId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
