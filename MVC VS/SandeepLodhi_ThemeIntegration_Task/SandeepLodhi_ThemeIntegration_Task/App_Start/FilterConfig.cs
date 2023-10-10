using System.Web;
using System.Web.Mvc;

namespace SandeepLodhi_ThemeIntegration_Task
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
