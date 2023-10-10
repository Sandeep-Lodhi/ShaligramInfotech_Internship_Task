using CRUDusingAJAX.Models.DBContext;
using CRUDusingAJAX.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDusingAJAX.Helpers.Helpers
{
    public class CRUDHelper
    {
        public static CustomerMaster RegisterUser(RegisterModel data)
        {
            CustomerMaster result = new CustomerMaster
            {
                Name = data.Name,
                Email=data.Email,
                Password=data.Password
            };
            return result;
        }
        public static RegisterModel GetUserById(CustomerMaster data)
        {
            RegisterModel result = new RegisterModel
            {
                CustId=data.CustId,
                Name = data.Name,
                Email=data.Email,
                Password=data.Password
            };
            return result;
        }
    }
}
