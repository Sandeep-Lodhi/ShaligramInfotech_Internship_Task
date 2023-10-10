using Exam.Models.DBContext;
using Exam.Models.Models;
using Exam.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository.Services
{
    public class ExamService : ExamInterface
    {
        KrunalDhote351Entities _Db = new KrunalDhote351Entities();
        public ExamService()
        {
            _Db.Configuration.ProxyCreationEnabled = false;
        }
        public bool GetUserName(string username)
        {
            var result = _Db.Authentication.Where(x=>x.UserName==username).FirstOrDefault();

            if (result!=null)
            {
                return true;
            }
            return false;
        }

        public bool LoginUser(UserModel user)
        {
            var result = _Db.Authentication.Where(x=>x.UserName==user.UserName && x.Password==user.Password).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            return false;
        }


        public IEnumerable GetQuestions()
        {
            var result = _Db.sp_GetQuistion().ToList();
            return result;
        }
    }
}
