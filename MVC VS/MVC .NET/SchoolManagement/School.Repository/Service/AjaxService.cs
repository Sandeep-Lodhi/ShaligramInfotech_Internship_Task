using School.Models.DBContext;
using School.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Service
{
    public class AjaxService:IAjaxInterface
    {
        KrunalDhote351Entities _DB = new KrunalDhote351Entities();
        public IEnumerable GetDepartment()
        {
            try
            {
                _DB.Configuration.ProxyCreationEnabled = false;
                var dept = _DB.Department.ToList();
                return dept;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable GetCountry()
        {
            try
            {
                _DB.Configuration.ProxyCreationEnabled = false;
                var country = _DB.Country.ToList();
                return country;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable GetState(int id)
        {
            try
            {
                _DB.Configuration.ProxyCreationEnabled = false;
                var state = _DB.State.Where(x => x.CountryId == id).ToList();
                return state;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable GetCity(int id)
        {
            try
            {
                _DB.Configuration.ProxyCreationEnabled = false;
                var city = _DB.City.Where(x => x.StateId == id).ToList();
                return city;
            }
            catch(Exception ex)
            {
                throw ex;
            }
}
    }
}
