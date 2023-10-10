using Helper.Helper;
using Models.DBContext;
using Models.Models;
using Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class StudentService:IStudentInterface
    {
        KrunalDhote351Entities _Db = new KrunalDhote351Entities();

        public int Register(StudentModel student)
        {
            return 0;
        }
        public IEnumerable Department()
        {
            try
            {
                return _Db.Department.ToList();
            }catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable Country()
        {
            try
            {
                _Db.Configuration.ProxyCreationEnabled = false;
                return _Db.Country.ToList();
            }catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable State(int? id)
        {
            try
            {
                _Db.Configuration.ProxyCreationEnabled = false;
                return _Db.State.Where(x=>x.CountryId==id).ToList();
            }catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable City(int? id)
        {
            try
            {
                _Db.Configuration.ProxyCreationEnabled = false;
                return _Db.City.Where(x=>x.StateId==id).ToList();
            }catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable GetDetails()
        {
            try
            {
                IEnumerable<Student> result= _Db.Student.ToList();
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public StudentModel Edit(int id)
        {
            var data = _Db.Student.Where(x => x.Id == id).FirstOrDefault();
            var result = StudentHelper.EditUser(data);
            return result;
        }
    }
}
