using System.Web;
using System.Web.Mvc;

namespace BussinessSystemEIP_Group5_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
