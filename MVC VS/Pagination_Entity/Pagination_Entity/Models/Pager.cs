using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Pagination_Entity.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set;  }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager()
        { 

        }
            public Pager(int totalItems, int page, int pageSize = 10)
            {
            int totalPages = (int)Math.Ceiling(decimal)totalItems / (decimal)pageSize);
               int currentPage = Page;

               int startPages = currentPage - 5;
                int endPage = currentPage + 4;

                if(StartPage <= 0)
            {
                endPage = endPage - (StartPage - 1);
                StartPage = 1;
            }
                if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage >10)
                {
                    StartPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPages;
            EndPage = endPage;
            }
        
    }
}





//------------------------------------------- INDEX
index(int pg = 1){

    const int pageSize = 10;
    if (pg < 1)
        pg = 1;

    int recsCount = product.Count();
    var pager = new Pager(recsCount, pg, pageSize);

    int recSkip = (pg - 1) * pageSize;
    var data = products.skip(recSkip).Take(PageSize).ToList(); 
}
