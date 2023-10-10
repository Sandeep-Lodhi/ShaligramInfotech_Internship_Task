using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Repository.Repository
{
    public interface ICountryInterface
    {
        string AddCountry(CountryCustomModel countrydata);
        List<CountryCustomModel> GetCountryList();

        Country DeleteCountryRecord(int id);

        CountryCustomModel EditCouuntryRecord(int id);

        int UpdateCountry(CountryCustomModel countrydata);

    }
}