using Models.DBContext;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Helper
{
    public class StudentHelper
    {
        public static StudentModel EditUser(Student data)
        {
            StudentModel result = new StudentModel
            {
                FirstName=data.FirstName,
                LastName=data.LastName,
                Email=data.Email,
                DateOfBirth=data.DateOfBirth,
                Gender=data.Gender,
                Address=data.Address,
                Password=data.Password,
                Contact=data.Contact,
                CityId=data.CityId,
                StateId=data.StateId,
                CountryId=data.CountryId,
                DepartmentId=data.DepartmentId,

            };
            return result;
        }
    }
}
