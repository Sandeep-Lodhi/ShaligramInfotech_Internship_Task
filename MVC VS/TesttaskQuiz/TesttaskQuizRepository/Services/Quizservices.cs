using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesttaskQuizModel.dbconext;
using TesttaskQuizRepository.Interface;

namespace TesttaskQuizRepository.Services
{
    public class Quizservices : Iquiz
    {
        lavan_386Entities dataobj = new lavan_386Entities();
        public List<Answers> answerslist(int id)
        {
            return dataobj.Answers.Where(x =>x.questionId==id).ToList();
        }
    }
}
