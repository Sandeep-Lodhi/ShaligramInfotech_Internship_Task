using MVC2_Test_Quiz.Models.DbContext;
using MVC2_Test_Quiz.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC2_Test_Quiz.Repository.Services
{
   public class HomeServices : IHomeInterface
    {
        SandeepTestDBEntities db =  new SandeepTestDBEntities();

        public List<SP_GetQuestionsAndAnswers_Result> GetQuestionById(int QId)
        {
            try
            {
                return db.SP_GetQuestionsAndAnswers().Where(x => x.QId == QId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
