using Phase3.Helpers.Helper;
using Phase3.Models.DbContext;
using Phase3.Models.Model;
using Phase3.Repositaries.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase3.Repositaries.Services
{
    public class AuthServices : IAuthInterface
    {

        Sandeep_Phase3Entities _DB = new Sandeep_Phase3Entities();
        public int Signup(AuthModel data)
        {
            var result = AuthHelpers.Signup(data);
            if (result != null)
            {
                _DB.User.Add(result);
                _DB.SaveChanges();
                return result.Id;
            }
            return 0;
        }



         public IList Index()
        {
            return _DB.User.ToList();
        }

        public AuthModel Edit(int Id)
        {
            var data = _DB.User.Where(x => x.Id == Id).FirstOrDefault();
            var result = AuthHelpers.Edit(data);
            return result;
        }
        public int Edit(User user)
        {

            var data = _DB.User.Where(x => x.Id == user.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = user.Id;
                data.Email = user.Email;
                data.UserName = user.UserName;
                data.Password = user.Password;
                _DB.User.Add(user);
                _DB.SaveChanges();
               
            }
            return Edit(user);
          
        }

        public int Details(int Id )
        {
            var data = _DB.User.Where(x => x.Id ==Id).FirstOrDefault();
            return Id;
        }

        public int Delete(int Id)
        {

              var data = _DB.User.Where(x => x.Id== Id).FirstOrDefault();
             _DB.User.Remove(data);
            _DB.SaveChanges();
            return 0;
            
        }

        public User GetUserById(int id)
        {
            User user = _DB.User.ToList().Find(x=>x.Id == id);

            return user;
        }
    }
}
