using SandeepMVC3_Test.Models.DbContext;
using SandeepMVC3_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandeepMVC3_Test.Helpers.Helpers
{
    public class AuthHelper
    {
        public static Registration SignUp(RegistrationModel registrationModel)
        {
            Registration r = new Registration();
            r.FirstName = registrationModel.FirstName;
            r.LastName = registrationModel.LastName;
            r.Email = registrationModel.Email;
            r.Password = registrationModel.Password;
            r.DOB = registrationModel.DOB;
            r.Address = registrationModel.Address;
            r.CountryId = registrationModel.CountryId;
            r.StateId = registrationModel.StateId;
            r.CityId = registrationModel.CityId;
            r.ProfilePic = registrationModel.ProfilePic;
            r.AttachmentDoc = registrationModel.AttachmentDoc;
            r.Gender = registrationModel.Gender;
            r.Hobbies = registrationModel.Hobbies;

            return r;
        }




        public static RegistrationModel Edit(Registration registration)
        {
            RegistrationModel registrationModel = new RegistrationModel();

            if (registrationModel != null)
            {
                registrationModel.id = registration.id;
                registrationModel.FirstName = registration.FirstName;
                registrationModel.LastName = registration.LastName;
                registrationModel.Email = registration.Email;
                registrationModel.Password = registration.Password;
                registrationModel.DOB = registration.DOB;
                registrationModel.Address = registration.Address;
                registrationModel.CountryId = registration.CountryId;
                registrationModel.StateId = registration.StateId;
                registrationModel.CityId = registration.CityId;
                registrationModel.ProfilePic = registration.ProfilePic;
                registrationModel.AttachmentDoc = registration.AttachmentDoc;
                registrationModel.Gender = registration.Gender;
                registrationModel.Hobbies = registration.Hobbies;



            }
            return registrationModel;
        }

        public static int Index(int id)
        {

            return Index(id);
        }

        public static int Delete(int id)
        {
            return Delete(id);
        }
    }
}
