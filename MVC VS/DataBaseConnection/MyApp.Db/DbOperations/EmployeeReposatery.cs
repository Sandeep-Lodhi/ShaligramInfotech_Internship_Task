using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Db.DbOperations
{
    public  class EmployeeReposatery
    {
        public int AddEmployee(EmoloyeeModel model)
        {
            using (var context = new SandeepMVCEntities())
            {
                Employee emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Code = model.Code
                };

                emp = context.Employee.Add(emp);

                context.SaveChanges();

                return emp.Id;
            }

        }

    }
}
