using PagedList;
using SandeepMVC_TestPractice.Models.DbContext;
using SandeepMVC_TestPractice.Models.Models;
using System.Collections;
using System.Linq;

namespace SandeepMVC_TestPractice.Helpers.Helpers
{
    public class AuthHelper
    {
        public static Registration SignUp(CustomAuthModel customAuthModel)
        {
            Registration reg = new Registration
            {
                FirstName = customAuthModel.FirstName,
                LastName = customAuthModel.LastName,
                Email = customAuthModel.Email,
                Password = customAuthModel.Password,
                DOB = customAuthModel.DOB,
                Address = customAuthModel.Address,
                CountryId = customAuthModel.CountryId,
                StateId = customAuthModel.StateId,
                CityId = customAuthModel.CityId,
                ProfilePic = customAuthModel.ProfilePic,
                AttachmentDoc = customAuthModel.AttachmentDoc,
                Gender = customAuthModel.Gender,
                Hobbies = customAuthModel.Hobbies

            };

            return (reg);
        }



        public static CustomAuthModel Edit(Registration registration)
        {
            CustomAuthModel customAuthModel = new CustomAuthModel();

            if (customAuthModel != null)
            {
                customAuthModel.id = registration.id;
                customAuthModel.FirstName = registration.FirstName;
                customAuthModel.LastName = registration.LastName;
                customAuthModel.Email = registration.Email;
                customAuthModel.Password = registration.Password;
                customAuthModel.DOB = registration.DOB;
                customAuthModel.Address = registration.Address;
                customAuthModel.CountryId = registration.CountryId;
                customAuthModel.StateId = registration.StateId;
                customAuthModel.CityId = registration.CityId;
                customAuthModel.ProfilePic = registration.ProfilePic;
                customAuthModel.AttachmentDoc = registration.AttachmentDoc;
                customAuthModel.Gender = registration.Gender;
                customAuthModel.Hobbies = registration.Hobbies;



            }
            return customAuthModel;
        }

        public static int Index(int id)
        {

            return Index(id);
        }

        public static int Delete(int id)
        {
            return Delete(id);
        }


        

        //public static IList index(string option, string search, int? pageNumber, string sort)
        //{
        //    Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();
        //    //if the sort parameter is null or empty then we are initializing the value as descending name  

        //    var SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";
        //    //if the sort value is gender then we are initializing the value as descending gender  
        //    var SortByGender = sort == "Gender" ? "descending gender" : "Gender";

        //    //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
        //    var records = db.Registration.AsQueryable();


        //    if (option == "FirstName")
        //    {
        //        db.Registration.Where(x => x.FirstName == search || search == null).ToList();
        //    }
        //    else if (option == "Gender")
        //    {
        //        db.Registration.Where(x => x.Gender == search || search == null).ToList();
        //    }
        //    else
        //    {
        //        db.Registration.Where(x => x.Email.StartsWith(search) || search == null).ToList();
        //    }

        //    switch (sort)
        //    {

        //        case "descending name":
        //            records = records.OrderByDescending(x => x.FirstName);
        //            break;

        //        case "descending gender":
        //            records = records.OrderByDescending(x => x.Gender);
        //            break;

        //        case "Gender":
        //            records = records.OrderBy(x => x.Gender);
        //            break;

        //        default:
        //            records = records.OrderBy(x => x.FirstName);
        //            break;

        //    }
        //    return records.ToPagedList(pageNumber ?? 1, 3).Cast<object>().ToList();
        //}
    }
}
