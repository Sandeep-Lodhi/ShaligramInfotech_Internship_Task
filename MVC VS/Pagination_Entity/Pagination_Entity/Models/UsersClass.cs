using EntityFrameworkPaginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagination_Entity.Models
{
    public  class UsersClass
    {
        public Page<Users> GetFilteredUsers(int pageSize, int currentPage, string searchText, int sortBy, string Address)
        {
            Page<Users> users;
            var filters = new Filters<Users>();
            filters.Add(!string.IsNullOrEmpty(searchText), x => x.FirstName.Contains(searchText));
            filters.Add(!string.IsNullOrEmpty(Address), x => x.Address.Equals(Address));

            var sorts = new Sorts<Users>();
            sorts.Add(sortBy == 1, x => x.Id);
            sorts.Add(sortBy == 2, x => x.FirstName);
            sorts.Add(sortBy == 3, x => x.Address);

            using (var context = new SandeepLodhi_SIT363Entities())
            {
                users = context.Users.Paginate(pageSize =5, currentPage,  sorts, filters);

            }
            return users;
        }
    }
}