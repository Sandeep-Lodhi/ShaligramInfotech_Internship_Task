using School.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Interface
{
    public interface IStudentInterface
    {
        int RegisterStudent(StudentModel student);
        int LoginStudent(string email,string password);
        IEnumerable GetDetails();
        bool DeleteStudent(int id);
        StudentModel GetOneDetail(int id);
    }
}
