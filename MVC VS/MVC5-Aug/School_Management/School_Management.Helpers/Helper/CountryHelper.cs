using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Helpers.UserHelper
{           
    public class CountryHelper
    {
        public static Country CustomTodbModel(CountryCustomModel data)
        {
            Country country = new Country()
            {
                CountryId=data.CountryId,
                CountryName=data.CountryName
            };

            return country;
        }

        public static List<CountryCustomModel> dbmodelTocustommodel(List<Country> data)
        {
            List<CountryCustomModel> customcountrydata = new List<CountryCustomModel>();
            foreach (var item in data)
            {
                CountryCustomModel countrlist = new CountryCustomModel();
                countrlist.CountryId = item.CountryId;
                countrlist.CountryName = item.CountryName;
                customcountrydata.Add(countrlist);
            }
            return customcountrydata;
        }

        public static CountryCustomModel dbmodelTocustom(Country data)
        {
            CountryCustomModel customcountry = new CountryCustomModel()
            {
                CountryId=data.CountryId,
                CountryName=data.CountryName
            };
            return customcountry;
        }
    }
}