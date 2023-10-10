using School.Helper.Helper;
using School.Models.DBContext;
using School.Models.Models;
using School.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Service
{
    public class StudentService:IStudentInterface
    {
        KrunalDhote351Entities _Db = new KrunalDhote351Entities();
        public int RegisterStudent(StudentModel student)
        {
            var result = StudentHelper.RegisterStudentHelper(student);
            if (result != null)
            {
                _Db.Student.Add(result);
                _Db.SaveChanges();
                return result.Id;
            }
            return 0;
        }

        public int LoginStudent(string email,string password)
        {
            var result=_Db.Student.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (result!= null)
            {
                return result.Id;
            }
            return 0;
        }
        public IEnumerable GetDetails()
        {
            IEnumerable<Student> result = _Db.Student.ToList();
            if (result!= null)
            {
                return result;
            }
            return null;
        }
        public bool DeleteStudent(int id)
        {
            var result = _Db.Student.Where(x=>x.Id==id).FirstOrDefault();
            if (result!= null)
            {
                _Db.Student.Remove(result);
                _Db.SaveChanges();
                return true;
            }
            return false;
        }
        public StudentModel GetOneDetail(int id)
        {
            var data = _Db.Student.Where(x => x.Id == id).FirstOrDefault();
            var result = StudentHelper.EditStudentHelper(data);
            
            if (result != null)
            {
                return result;
            }return null;
            
        }
    }
}
