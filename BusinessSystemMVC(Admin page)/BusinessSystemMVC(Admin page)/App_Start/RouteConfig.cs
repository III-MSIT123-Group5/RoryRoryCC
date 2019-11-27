using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BusinessSystemMVC_Admin_page_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "SelectRegister",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Account", action = "GetGrpIDbyDeptID", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "GetManagerIDRoute",
                url: "{ controller }/{action}/{DepartmentID}/{GroupID}/{PositionID}",
                defaults: new { controller = "Account", action = "GetManagerID", DepartmentID = UrlParameter.Optional, GroupID = UrlParameter.Optional, PositionID = UrlParameter.Optional }
                   );

            routes.MapRoute(
            name: "BulletinBoards",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "BulletinBoards", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
