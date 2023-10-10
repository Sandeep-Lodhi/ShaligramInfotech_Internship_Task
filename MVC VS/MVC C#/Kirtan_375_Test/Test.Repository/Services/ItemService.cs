using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.DbContext;
using Test.Repository.Repository;

namespace Test.Repository.Services
{
    public class ItemService : IItems
    {
        public Kirtan_test_375Entities dbContext = new Kirtan_test_375Entities();
        public IEnumerable<Items> GetItems()
        {
            return dbContext.Items.ToList();
        }
    }
}
