using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Repository.Repository
{
    public interface ICityInterface
    {
        string AddCity(CityCustomModel CityData);
        List<State> StateList();

        List<Country> CountryList();

        List<CityList_Result> GetCitylist();

        CityCustomModel GetCity(int id);
        string EditCity(CityCustomModel city);
        City DeleteCityRecord(int id);
    }
}
