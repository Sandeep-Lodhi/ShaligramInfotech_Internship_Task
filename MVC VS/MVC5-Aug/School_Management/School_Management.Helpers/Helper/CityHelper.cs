
using School_Management.Models.Context;
using School_Management.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Helpers.Helper
{
    public class CityHelper
    {
        //public static City CustomCitylist_To_DBlist(CityCustomModel data)
        //{
        //    City citydata = new City()
        //    { 
        //        CityId=data.CityId,
        //        CityName=data.CityName,
        //        StateId=data.StateId,
        //        CountryId=data.CountryId
        //    };
        //    return citydata;
        //}
        public static CityCustomModel DbToCustom(City data)
        {
            try
            {
                CityCustomModel cityCustom = new CityCustomModel();
                cityCustom.CityId = data.CityId;
                cityCustom.CityName = data.CityName;
                cityCustom.StateId = (int)data.StateId;
                cityCustom.CountryId = (int)data.CountryId;
                return cityCustom;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
