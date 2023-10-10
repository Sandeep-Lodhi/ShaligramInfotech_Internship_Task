using StudentManagement.AuthFilter;
using StudentManagement.Models;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    [Authentication]
    public class StudentController : Controller
    {

        IStudentInterface studentInterface;
        IStandardInterface standardInterface;
        ICountryInterface countryInterface;


        public StudentController(IStudentInterface studentInterface, IStandardInterface standardInterface, ICountryInterface countryInterface)
        {
            this.studentInterface = studentInterface;
            this.standardInterface = standardInterface;
            this.countryInterface = countryInterface;
        }

        public ActionResult CreateStudent(int? StudentId = null)
        {
            try
            {
                ViewBag.DefaultValue = "2001-28-10";
                ViewBag.StandardList = standardInterface.GetStandardList();
                ViewBag.CountryList = countryInterface.GetCountryList();
                if (StudentId == null)
                {
                    return View(new StudentModel());
                }
                else
                {
                    StudentModel studentModel = studentInterface.GetAllStudents().Where(x => x.StudentId == StudentId).FirstOrDefault();
                    ViewBag.StateList = standardInterface.GetStateByCountryId(studentModel.StudentCountryId);
                    ViewBag.CityList = standardInterface.GetCityByStateId(studentModel.StudentStateId);
                    ViewBag.SubjectList = standardInterface.GetSubjectByStandardId(studentModel.StudentStandardId);
                    ViewBag.TeacherList = standardInterface.GetTeacherBySubjectId(string.Join(",", studentModel.StudentSubjectId.Select(x => x)));

                    return View(studentModel);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentModel studentModel)
        {
            try
            {
                if (studentModel.StudentId == 0)
                {
                    studentInterface.AddStudent(studentModel);
                }
                else
                {
                    studentInterface.EditStudent(studentModel);
                }
                return RedirectToAction("RetriveStudents");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult RetriveStudents()
        {
            List<StudentModel> StudentModelList = new List<StudentModel>();
            try
            {
                StudentModelList = studentInterface.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(StudentModelList);
        }

        public ActionResult StudentDetail(int StudentId)
        {
            try
            {
                StudentModel Student = studentInterface.GetAllStudents().Where(x => x.StudentId == StudentId).ToList().FirstOrDefault();
                return View(Student);
            }
            catch
            {
                ViewBag.message = "No User Detail Found";
                return View();
            }
        }

        public ActionResult GetSubjectsByStandardId(int StandardId)
        {
            try
            {
                return Json(standardInterface.GetSubjectByStandardId(StandardId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetTeacherBySubjectId(string SubjectId)
        {
            try
            {
                return Json(standardInterface.GetTeacherBySubjectId(SubjectId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetStateByCountryId(int CountryId)
        {
            try
            {
                return Json(standardInterface.GetStateByCountryId(CountryId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetCityByStateId(int StateId)
        {
            try
            {
                return Json(standardInterface.GetCityByStateId(StateId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GetUpdateStudent(int? StudentId = null)
        {
            try
            {
                return Json(studentInterface.GetAllStudents().Where(x => x.StudentId == StudentId).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteStudent(int studentId)
        {
            StudentModel studentModel = studentInterface.GetAllStudents().Where(x => x.StudentId == studentId).FirstOrDefault();
            return View(studentModel);
        }

        [HttpPost]
        public ActionResult ConformDeleteStudent(int studentId)
        {
            try
            {
                studentInterface.DeleteStudent(studentId);
                return RedirectToAction("RetriveStudents");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}