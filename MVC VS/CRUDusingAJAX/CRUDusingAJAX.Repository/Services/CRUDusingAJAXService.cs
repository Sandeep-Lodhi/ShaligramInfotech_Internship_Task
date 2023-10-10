using CRUDusingAJAX.Models.DBContext;
using CRUDusingAJAX.Models.Models;
using CRUDusingAJAX.Helpers.Helpers;
using System;
using System.Linq;
using CRUDusingAJAX.Repository.Interfaces;
using System.Collections;

namespace CRUDusingAJAX.Repository.Services
{
    public class CRUDusingAJAXService:ICRUDusingAJAX
    {
        KrunalDhote351Entities _Db = new KrunalDhote351Entities();
        public int RegisterService(RegisterModel data)
        {
            try
            {
                if (data.CustId != 0)
                {
                    var result = _Db.CustomerMaster.Where(x => x.CustId == data.CustId).FirstOrDefault();

                    result.Name = data.Name;
                    result.Email = data.Email;
                    result.Password = data.Password;

                    _Db.SaveChanges();
                    return result.CustId;
                }
                else
                {
                    var result = CRUDHelper.RegisterUser(data);
                    _Db.CustomerMaster.Add(result);
                    _Db.SaveChanges();
                    return result.CustId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool LoginService(LoginModel data)
        {
            try
            {
                var result = _Db.CustomerMaster.Where(x => x.Email == data.email && x.Password == data.password).FirstOrDefault();
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable GetUsers()
        {
            try
            {
                var result = _Db.CustomerMaster.ToList();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public RegisterModel GetUserById(int id)
        {
            try
            {
                var data = _Db.CustomerMaster.Where(x => x.CustId == id).FirstOrDefault();
                var result = CRUDHelper.GetUserById(data);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
