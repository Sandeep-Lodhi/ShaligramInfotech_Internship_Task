using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{

    public enum Gender
    {
        Male,
        Female
    }
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentAddress { get; set; }
        public string StudentMobileNo { get; set; }
        public string StudentEmail { get; set; }
        public string StudentGenderName { get; set; }

        public int StudentGenderId { get; set; }

        public DateTime StudentDOB { get; set; }
        public int StudentStandardId { get; set; }
        public string StudentStandardName { get; set; }


        public int StudentCountryId { get; set; }
        public string StudentCountryName { get; set; }

        public int StudentStateId { get; set; }
        public string StudentStateName { get; set; }

        public int StudentCityId { get; set; }
        public string StudentCityName { get; set; }

        public List<int> StudentSubjectId { get; set; }
        public List<string> StudentSubjectName { get; set; }

        public List<int> StudentTeacherId { get; set; }
        public List<string> StudentTeacherName { get; set; }

    }
}