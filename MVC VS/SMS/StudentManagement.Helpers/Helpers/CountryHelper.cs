
using StudentManagement.Models.Context;
using StudentManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Helpers.Helpers
{
    public class CountryHelper
    {
        public List<CountryModel> ConvertCountryListToCountryModelList(List<Country> CountryList)
        {
            List<CountryModel> countryModelList = new List<CountryModel>();
            foreach (Country country in CountryList)
            {
                countryModelList.Add(
                    new CountryModel()
                    {
                        CountryId = country.CountryId,
                        CountryName = country.CountryName
                    }
                    );
            };

            return countryModelList;
        }
    }
}
