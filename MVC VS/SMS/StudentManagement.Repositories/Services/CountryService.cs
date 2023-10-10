using StudentManagement.Helpers;
using StudentManagement.Helpers.Helpers;
using StudentManagement.Models.Context;
using StudentManagement.Models.Models;
using StudentManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Services
{
    public class CountryService : ICountryInterface
    {
        SP355SanjayPrajapatiEntities db = new SP355SanjayPrajapatiEntities();


        public int CreateNewCountry(CountryModel countryModel)
        {
            try
            {
                if (countryModel.CountryId == 0)
                {
                    if (db.Country.Any(x => x.CountryName.ToLower() == countryModel.CountryName.ToLower()))
                    {
                        return 0;
                    }

                    db.Sp_AddEditCountry(null, countryModel.CountryName);
                    return 1;
                }
                if (db.Country.Where(x => x.CountryName.ToLower() == countryModel.CountryName.ToLower()).Count() > 1)
                {
                    return 0;
                }
                db.Sp_AddEditCountry(countryModel.CountryId, countryModel.CountryName);

                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CountryModel GetCountryById(int CountryId)
        {
            return GetCountryList().FirstOrDefault(x => x.CountryId == CountryId);
        }

        public List<CountryModel> GetCountryList()
        {
            return new CountryHelper().ConvertCountryListToCountryModelList(db.Country.ToList());
        }
    }
}
