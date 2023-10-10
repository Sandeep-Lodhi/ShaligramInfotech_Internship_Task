using SanjayTest.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjayTest.Repository.Repository
{
    public interface IHomeInterface
    {
        List<SP_GetQuestionsAndAnswers_Result> GetQuestionById(int QId);
    }
}
