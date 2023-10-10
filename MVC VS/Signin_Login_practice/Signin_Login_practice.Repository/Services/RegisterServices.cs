using Signin_Login_practice.Helpers.Helpers;
using Signin_Login_practice.Models.DbContext;
using Signin_Login_practice.Models.Models;
using Signin_Login_practice.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signin_Login_practice.Repository.Services
{
    public class RegisterServices : IRegister
    {
        Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();

        public void Register(CustomRegisterModel customRegisterModel)
        {
            var Helper = CustomRegisterHelper.Register(customRegisterModel);
            db.Registration.Add(Helper);
            db.SaveChanges();
        }

        public List<Country> GetCountry()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var C = db.Country.ToList();
            return C;
        }

        public List<State> GetState(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var S = db.State.Where(x => x.Cid ==id).ToList();
            return S;
        }

        public List<City> GetCity(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var C = db.City.Where(x => x.Sid == id).ToList();
            return C;
        }

        public Registration Login(CustomRegisterModel customRegisterModel)
        {
            var check = db.Registration.Where(x => x.Email.Equals(customRegisterModel.Email) && x.Password.Equals(customRegisterModel.Password)).FirstOrDefault();
         
            try
            {
                if (check != null)
                {
                    return db.Registration.Where(x => x.Email.ToString().ToUpper() == customRegisterModel.Email.ToString().ToUpper() && x.Password.ToString().ToUpper() == customRegisterModel.Password.ToString().ToUpper()).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public IList index()
        {
            return db.Registration.ToList();
        }

        public CustomRegisterModel Edit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Registration.Where(x => x.id == id).FirstOrDefault();
            var result = CustomRegisterHelper.Edit(data);

            return result;
        }

        public int Edit(Registration registration)
        {
    
            var data = db.Registration.Where(x => x.id == registration.id).FirstOrDefault();

            data.id = registration.id;
            data.FirstName = registration.FirstName;
            data.LastName = registration.LastName;
            data.Email = registration.Email;
            data.Password = registration.Password;
            data.DOB = registration.DOB;
            data.Address = registration.Address;
            data.CountryId = registration.CountryId;
            data.StateId = registration.StateId;
            data.CityId = registration.CityId;
            data.ProfilePic = registration.ProfilePic;
            data.AttachmentDoc = registration.AttachmentDoc;
            data.Gender = registration.Gender;
            data.Hobbies = registration.Hobbies;
            db.SaveChanges();
            return 0;

        }


        public CustomRegisterModel Details(int id)
        {
            CustomRegisterModel data =new  CustomRegisterModel();

            var match = db.Registration.Where(x => x.id == id).FirstOrDefault();
            foreach(Registration user in db.Registration.Where(x => x.id == id).ToList())
            {
                data.id = match.id;
                data.FirstName = match.FirstName;
                data.LastName = match.LastName;
                data.Email = match.Email;
                data.Password = match.Password;
                data.DOB = match.DOB;
                data.Address = match.Address;
                data.CountryId = match.CountryId;
                data.StateId = match.StateId;
                data.CityId = match.CityId;
                data.ProfilePic = match.ProfilePic;
                data.AttachmentDoc = match.AttachmentDoc;
                data.Gender = match.Gender;
                data.Hobbies = match.Hobbies;

            }
                return data;
        }

        public int Delete(int id)
        {
            var data = db.Registration.Where(x => x.id == id).FirstOrDefault();
            db.Registration.Remove(data);
            db.SaveChanges();
            return 0;
        }


    }
}
