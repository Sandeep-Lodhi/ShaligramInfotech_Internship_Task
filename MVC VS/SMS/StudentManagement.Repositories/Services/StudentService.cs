using StudentManagement.Helpers.Helpers;
using StudentManagement.Models;
using StudentManagement.Models.Context;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Services
{
    public class StudentService : IStudentInterface
    {
        SP355SanjayPrajapatiEntities db = new SP355SanjayPrajapatiEntities();

        public List<StudentModel> GetAllStudents()
        {
            try
            {
                return new StudentHelper().BindStudentToStudentModel(db.Student.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddStudent(StudentModel studentModel)
        {
            try
            {
                string StudentGenderName = studentModel.StudentGenderId == 0 ? "Male" : "Female";
                string StudentSubjectId = string.Join<int>(",", studentModel.StudentSubjectId);
                string StudentTeacherId = string.Join<int>(",", studentModel.StudentTeacherId);

                return db.Sp_AddEditStudent
                    (
                    null,
                    studentModel.StudentFirstName,
                    studentModel.StudentLastName,
                    studentModel.StudentAddress,
                    studentModel.StudentMobileNo,
                    studentModel.StudentEmail,
                    StudentGenderName,
                    studentModel.StudentDOB,
                    studentModel.StudentStandardId,
                    studentModel.StudentCountryId,
                    studentModel.StudentStateId,
                    studentModel.StudentCityId,
                    StudentSubjectId,
                    StudentTeacherId
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditStudent(StudentModel studentModel)
        {
            try
            {
                string StudentGenderName = studentModel.StudentGenderId == 0 ? "Male" : "Female";
                string StudentSubjectId = string.Join<int>(",", studentModel.StudentSubjectId);
                string StudentTeacherId = string.Join<int>(",", studentModel.StudentTeacherId);

                return db.Sp_AddEditStudent
                    (
                    studentModel.StudentId,
                    studentModel.StudentFirstName,
                    studentModel.StudentLastName,
                    studentModel.StudentAddress,
                    studentModel.StudentMobileNo,
                    studentModel.StudentEmail,
                    StudentGenderName,
                    studentModel.StudentDOB,
                    studentModel.StudentStandardId,
                    studentModel.StudentCountryId,
                    studentModel.StudentStateId,
                    studentModel.StudentCityId,
                    StudentSubjectId,
                    StudentTeacherId
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteStudent(int StudentId)
        {
            try
            {
                return db.DeleteStudentById(StudentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
