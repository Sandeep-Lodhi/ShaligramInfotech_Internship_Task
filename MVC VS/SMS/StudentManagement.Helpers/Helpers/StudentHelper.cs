using StudentManagement.Models;
using StudentManagement.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helpers.Helpers
{

    public class StudentHelper
    {
        public List<StudentModel> BindStudentToStudentModel(List<Student> StudentsList)
        {
            List<StudentModel> StudentModelList = new List<StudentModel>();
            try
            {
                foreach (Student Student in StudentsList)
                {
                    StudentModel newStudent = new StudentModel();
                    newStudent.StudentId = Student.StudentId;
                    newStudent.StudentFirstName = Student.StudentFirstName;
                    newStudent.StudentLastName = Student.StudentLastName;
                    newStudent.StudentAddress = Student.StudentAddress;
                    newStudent.StudentMobileNo = Student.StudentMobileNo;
                    newStudent.StudentEmail = Student.StudentEmail;
                    newStudent.StudentGenderName = Student.StudentGenderName;
                    newStudent.StudentDOB = (DateTime)Student.StudentDOB;
                    newStudent.StudentStandardId = (int)Student.StudentStandardId;
                    newStudent.StudentCountryId = (int)Student.StudentCountryId;
                    newStudent.StudentStateId = (int)Student.StudentStateId;
                    newStudent.StudentCityId = (int)Student.StudentCityId;

                    newStudent.StudentStandardName = Student.Standard.StandardName;
                    newStudent.StudentCountryName = Student.Country.CountryName;
                    newStudent.StudentStateName = Student.State.StateName;
                    newStudent.StudentCityName = Student.City.CityName;
                    newStudent.StudentSubjectId= Student.StudentSubject.Select(x => x.Subject.SubjectId).ToList();
                    newStudent.StudentTeacherId = Student.StudentTeacher.Select(x => x.Teacher.TeacherId).ToList();
                    newStudent.StudentSubjectName = Student.StudentSubject.Select(x => x.Subject.SubjectName).ToList();
                    newStudent.StudentTeacherName = Student.StudentTeacher.Select(x => x.Teacher.TeacherFirstName + " " + x.Teacher.TeacherLastName).ToList();
                    StudentModelList.Add(newStudent);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return StudentModelList;
        }

    }
}
