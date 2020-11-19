using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TMDT_ver4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TMDT_ver4.Controllers" }
            )/*.DataTokens["area"] = "Admin"*/;

            //routes.MapRoute(
            //    name: "Them Gio Hang",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "GioHang", action = "ThemSP", id = UrlParameter.Optional },
            //    namespaces: new[] { "TMDT_ver4.Controllers" }
            //    );
        }
    }
}
