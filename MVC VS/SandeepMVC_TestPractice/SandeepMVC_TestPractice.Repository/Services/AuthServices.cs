using PagedList;
using SandeepMVC_TestPractice.Helpers.Helpers;
using SandeepMVC_TestPractice.Models.DbContext;
using SandeepMVC_TestPractice.Models.Models;
using SandeepMVC_TestPractice.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandeepMVC_TestPractice.Repository.Services
{

    public class AuthServices : IAuth
    {
        Sandeep_Phase3Entities db = new Sandeep_Phase3Entities();

       //public IList index(string option, string search, int? pageNumber, string sort)
       // {
       //     AuthHelper.index(option, search, pageNumber, sort);
       //     return db.Registration.ToList();
       // }

        public IList index()
        {
            return db.Registration.ToList();
        }


        public void SignUp(CustomAuthModel customAuthModel)
        {
            var authHelper = AuthHelper.SignUp(customAuthModel);
            db.Registration.Add(authHelper);
            db.SaveChanges();
        }


        public  Registration Login(CustomAuthModel customAuthModel)
        {
            var checkLogin = db.Registration.Where(x => x.Email.Equals(customAuthModel.Email) && x.Password.Equals(customAuthModel.Password)).FirstOrDefault();
            try
            {
                if (checkLogin != null)
                {
                    return db.Registration.Where(x => x.Email.ToString().ToUpper() == customAuthModel.Email.ToString().ToUpper() && x.Password == customAuthModel.Password).FirstOrDefault();
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
            var li =db.Country.ToList();
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

        public CustomAuthModel ShowUser(int id)
        {
            CustomAuthModel userdata = new CustomAuthModel();
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

        public CustomAuthModel Edit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Registration.Where(x => x.id ==id).FirstOrDefault();

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




        //public bool UpdateUser(int id, Registration registration)
        //{
        //    try
        //    {

        //        var SelectedUser = db.Registration.Find(id);
        //        SelectedUser.FirstName = registration.FirstName;
        //        SelectedUser.LastName = registration.LastName;
        //        SelectedUser.Email = registration.Email;
        //        SelectedUser.Password = registration.Password;
        //        SelectedUser.DOB = registration.DOB;
        //        SelectedUser.Address = registration.Address;
        //        SelectedUser.CountryId = registration.CountryId;
        //        SelectedUser.StateId = registration.StateId;
        //        SelectedUser.CityId = registration.CityId;
        //        SelectedUser.ProfilePic = registration.ProfilePic;
        //        SelectedUser.AttachmentDoc = registration.AttachmentDoc;
        //        SelectedUser.Gender = registration.Gender;
        //        SelectedUser.Hobbies = registration.Hobbies;
        //        db.SaveChanges();
        //        return true;

        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

        public int Delete(int id)
        {
            var data = db.Registration.Where(x => x.id == id).FirstOrDefault();
            db.Registration.Remove(data);
            db.SaveChanges();
            return 0;
        }


       public  Registration GetUserById(int id)
        {
            Registration registration = db.Registration.ToList().Find(x => x.id == id);

            return registration;
        }

    }
}
