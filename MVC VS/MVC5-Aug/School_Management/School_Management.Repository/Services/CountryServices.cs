using School_Management.Helpers.UserHelper;
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
    public class CountryServices : ICountryInterface
    {
        Ram_School_Management_352Entities dbContext = new Ram_School_Management_352Entities();
        public string AddCountry(CountryCustomModel countrydata)
        {
            Country country = CountryHelper.CustomTodbModel(countrydata);
            if (country != null)
            {
                dbContext.Country.Add(country);
                dbContext.SaveChanges();
                return "pass";
            }
            else
            {
                return "fail";
            }
        }

        public List<CountryCustomModel> GetCountryList()
        {
            try
            {
                List<Country> CountryList = new List<Country>();

                List<CountryCustomModel> CustomCountryList = new List<CountryCustomModel>();

                CountryList = dbContext.Country.ToList();

                CustomCountryList = CountryHelper.dbmodelTocustommodel(CountryList);
                if (CustomCountryList != null && CustomCountryList.Count > 0)
                {
                    return CustomCountryList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Country DeleteCountryRecord(int id)
        {
            var deletecountry = dbContext.Country.Find(id);
            if (deletecountry != null)
            {
                var delete = dbContext.Country.Remove(deletecountry);
                dbContext.SaveChanges();
                return delete;
            }
            else
            {
                return null;
            }
        }
        public CountryCustomModel EditCouuntryRecord(int id)
        {
            Country country;
            country = dbContext.Country.Find(id);

            CountryCustomModel countryCustomModel = CountryHelper.dbmodelTocustom(country);
            return countryCustomModel;
        }

        public int UpdateCountry(CountryCustomModel data)
        {
            try
            {
                Country country = CountryHelper.CustomTodbModel(data);
                dbContext.Entry(country).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}