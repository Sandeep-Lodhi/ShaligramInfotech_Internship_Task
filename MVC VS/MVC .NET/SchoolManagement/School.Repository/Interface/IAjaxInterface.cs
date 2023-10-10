using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Interface
{
    public interface IAjaxInterface
    {
        IEnumerable GetDepartment();
        IEnumerable GetCountry();
        IEnumerable GetState(int id);
        IEnumerable GetCity(int id);
    }
}
