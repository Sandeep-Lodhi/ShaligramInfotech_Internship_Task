using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesttaskQuizModel.dbconext;

namespace TesttaskQuizRepository.Interface
{
   public interface Iquiz
    {
        List<Answers> answerslist(int id);
    }
}
