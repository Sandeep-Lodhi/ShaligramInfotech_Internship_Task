using School_Management.Helpers.Helper;
using School_Management.Models.Context;
using School_Management.Models.Model;
using School_Management.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Repository.Services
{
    public class CityServices : ICityInterface
    {
    Ram_School_Management_352Entities dbContext = new Ram_School_Management_352Entities();
        public string AddCity(CityCustomModel CityData)
        {
            //City citydata = CityHelper.CustomCitylist_To_DBlist(CityData);

            //if (citydata != null)
            //{
            //    dbContext.City.Add(citydata);
            //    dbContext.SaveChanges();
            //    return "pass";
            //}
            //else
            //{
            //    return "fail";
            //}

            try
            {
               var cityexist= dbContext.City.Where(x => x.CityName.Equals(CityData.CityName)).FirstOrDefault();
                if (cityexist!=null)
                {
                    return "fail";
                }
                else
                {
                    dbContext.sp_cityadd_edit(null, CityData.CityName, CityData.StateId, CityData.CountryId);
                    dbContext.SaveChanges();
                    return "pass";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<State> StateList()
        {        
            List<State> statelist = new List<State>();
            statelist = dbContext.State.ToList();
            return statelist;
        }
        public List<Country> CountryList()
        {
            List<Country> countrylist = new List<Country>();
            countrylist = dbContext.Country.ToList();
            return countrylist;
        }

        public List<CityList_Result> GetCitylist()
        {
            List<CityList_Result> CityList = dbContext.CityList().ToList();

            if (CityList != null && CityList.Count > 0)
            {
                return CityList;
            }
            else
            {
                return null;
            }
        }
        public CityCustomModel GetCity(int id)
        {
            City city = dbContext.City.Find(id);
            CityCustomModel cityModel = CityHelper.DbToCustom(city);
            return cityModel;
        }
        public string EditCity(CityCustomModel CityData)
        {
            try
            {
                var cityexist = dbContext.City.Where(x => x.CityId.Equals(CityData.CityId)).FirstOrDefault();
                if (cityexist != null)
                {
                    dbContext.sp_cityadd_edit(CityData.CityId, CityData.CityName, CityData.StateId, CityData.CountryId);
                    dbContext.SaveChanges();
                    return "pass";
                }
                else
                {
                    return "fail";
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public City DeleteCityRecord(int id)
        {
            var DeleteCity = dbContext.City.Find(id);
            if (DeleteCity != null)
            {
                var delete = dbContext.City.Remove(DeleteCity);
                dbContext.SaveChanges();
                return delete;
            }
            else {
                return null;
            }
        }
    }
}
