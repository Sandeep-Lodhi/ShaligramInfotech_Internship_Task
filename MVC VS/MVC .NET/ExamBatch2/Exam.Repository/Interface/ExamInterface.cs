using Exam.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository.Interface
{
    public interface ExamInterface
    {
        bool GetUserName(string username);
        bool LoginUser(UserModel user);
        IEnumerable GetQuestions();
    }
}
