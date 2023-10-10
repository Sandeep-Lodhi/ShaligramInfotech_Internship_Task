using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Repositories
{
    public interface IStudentInterface
    {

        List<StudentModel> GetAllStudents();
        int AddStudent(StudentModel studentModel);

        int EditStudent(StudentModel studentModel);

        int DeleteStudent(int StudentId);

    }
}
