using School.Models.DBContext;
using School.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Helper.Helper
{
    public class StudentHelper
    {
        public static Student RegisterStudentHelper(StudentModel student)
        {
            Student result = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Address = student.Address,
                Contact=student.Contact,
                DepartmentId = student.DepartmentId,
                CountryId=student.CountryId,
                StateId=student.StateId,
                CityId=student.CityId,
                Password=student.Password
            };
            return result;
        }
        public static StudentModel EditStudentHelper(Student student)
        {
            StudentModel result = new StudentModel()
            {
                Id=student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Address = student.Address,
                Contact=student.Contact,
                DepartmentId = student.Department.Id,
                CountryId=student.Country.id,
                StateId=student.State.id,
                CityId=student.City.id,
                Password=student.Password
            };
            return result;
        }
    }
}
