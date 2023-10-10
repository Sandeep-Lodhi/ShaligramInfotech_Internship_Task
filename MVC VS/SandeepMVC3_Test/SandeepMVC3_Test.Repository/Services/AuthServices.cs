using SandeepMVC3_Test.Helpers.Helpers;
using SandeepMVC3_Test.Models.DbContext;
using SandeepMVC3_Test.Models.Models;
using SandeepMVC3_Test.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandeepMVC3_Test.Repository.Services
{
    public class AuthServices : IAuth
    {
        SandeepTestDBEntities db = new SandeepTestDBEntities();


        void IAuth.SignUp(RegistrationModel registrationModel)
        {
            var auth = AuthHelper.SignUp(registrationModel);
            db.Registration.Add(auth);
            db.SaveChanges();
        }

        public Registration Login(RegistrationModel registrationModel) { 
            var checkLogin = db.Registration.Where(x => x.Email.Equals(registrationModel.Email) && x.Password.Equals(registrationModel.Password)).FirstOrDefault();
            try
            {
                if (checkLogin != null)
                {
                    return db.Registration.Where(x => x.Email.ToString().ToUpper() == registrationModel.Email.ToString().ToUpper() && x.Password == registrationModel.Password).FirstOrDefault();
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

        public List<Country> GetCountry()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var li = db.Country.ToList();
            return li;
        }

        public List<State> GetState(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var li = db.State.Where(x => x.Cid == id).ToList();
            return li;
        }

        public List<City> GetCity(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var li = db.City.Where(x => x.Sid == id).ToList();
            return li;
        }


        public RegistrationModel ShowUser(int id)
        {
            RegistrationModel userdata = new RegistrationModel();
            var match = db.Registration.Where(x => x.id == id).FirstOrDefault();
            foreach (Registration user in db.Registration.Where(x => x.id == id).ToList())
            {
                userdata.id = match.id;
                userdata.FirstName = match.FirstName;
                userdata.LastName = match.LastName;
                userdata.Email = match.Email;
                userdata.Password = match.Password;
                userdata.DOB = match.DOB;
                userdata.Address = match.Address;
                userdata.CountryId = match.CountryId;
                userdata.StateId = match.StateId;
                userdata.CityId = match.CityId;
                userdata.ProfilePic = match.ProfilePic;
                userdata.AttachmentDoc = match.AttachmentDoc;
                userdata.Gender = match.Gender;
                userdata.Hobbies = match.Hobbies;
            }
            return userdata;
        }


        public IList index()
        {
            return db.Registration.ToList();
        }


        public RegistrationModel Edit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Registration.Where(x => x.id == id).FirstOrDefault();

            var result = AuthHelper.Edit(data);
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


        public int Delete(int id)
        {
            var data = db.Registration.Where(x => x.id == id).FirstOrDefault();
            db.Registration.Remove(data);
            db.SaveChanges();
            return 0;
        }


        public Registration GetUserById(int id)
        {
            Registration registration = db.Registration.ToList().Find(x => x.id == id);

            return registration;
        }

    }
}
