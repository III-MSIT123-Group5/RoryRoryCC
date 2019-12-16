using System.Web;
using System.Web.Mvc;

namespace BusinessSystemMVC_Admin_page_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
