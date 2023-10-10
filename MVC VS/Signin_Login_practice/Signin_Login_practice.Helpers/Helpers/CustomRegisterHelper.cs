using Signin_Login_practice.Models.DbContext;
using Signin_Login_practice.Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin_Login_practice.Helpers.Helpers
{
    public static class CustomRegisterHelper
    {
        public static Registration Register(CustomRegisterModel customRegisterModel)
        {
            Registration reg = new Registration();
            reg.FirstName = customRegisterModel.FirstName;
            reg.LastName = customRegisterModel.LastName;
            reg.Email = customRegisterModel.Email;
            reg.Password = customRegisterModel.Password;
            reg.DOB = customRegisterModel.DOB;
            reg.Address = customRegisterModel.Address;
            reg.CountryId = customRegisterModel.CountryId;
            reg.StateId = customRegisterModel.StateId;
            reg.CityId = customRegisterModel.CityId;
            reg.ProfilePic = customRegisterModel.ProfilePic;
            reg.AttachmentDoc = customRegisterModel.AttachmentDoc;
            reg.Gender = customRegisterModel.Gender;
            reg.Hobbies = customRegisterModel.Hobbies;

            return (reg);
        }


        public static CustomRegisterModel Edit(Registration registration)
        {
            CustomRegisterModel customRegisterModel  = new CustomRegisterModel();
            if (customRegisterModel  != null)
            {
                customRegisterModel.id = registration.id;
                customRegisterModel.FirstName = registration.FirstName;
                customRegisterModel.LastName = registration.LastName;
                customRegisterModel.Email = registration.Email;
                customRegisterModel.Password = registration.Password;
                customRegisterModel.DOB = registration.DOB;
                customRegisterModel.Address = registration.Address;
                customRegisterModel.CountryId = registration.CountryId;
                customRegisterModel.StateId = registration.StateId;
                customRegisterModel.CityId = registration.CityId;
                customRegisterModel.ProfilePic = registration.ProfilePic;
                customRegisterModel.AttachmentDoc = registration.AttachmentDoc;
                customRegisterModel.Gender = registration.Gender;
                customRegisterModel.Hobbies = registration.Hobbies;
            }

            return customRegisterModel;

        }


        public static IList index(int id)
        {
            return index(id);
        }

        public static int Delete(int id)
        {
            return Delete(id);
        }

    }
}
