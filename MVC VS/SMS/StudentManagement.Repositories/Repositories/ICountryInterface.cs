using StudentManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Repositories.Repositories
{
    public interface ICountryInterface
    {
        List<CountryModel> GetCountryList();

        int CreateNewCountry(CountryModel countryModel);

        CountryModel GetCountryById(int CountryId);
    }
}
