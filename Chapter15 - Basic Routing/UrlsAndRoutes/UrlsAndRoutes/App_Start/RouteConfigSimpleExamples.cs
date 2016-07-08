using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfigSimpleExamples
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ~/Shop/OldAction (display) but calls ~/Home/Index
            routes.MapRoute("ShopSchema2", "Shop/OldAction",
                new { controller = "Home", action = "Index" });

            //  ~/Shop/Index (display)  buts calls ~/Home/Index
            routes.MapRoute("ShopSchema", "Shop/{action}",
                new { controller = "Home" });

            //  ~/XHome/Index
            routes.MapRoute("", "X{controller}/{action}");

            //  ~/Home/Index or ~/ or ~/Home
            routes.MapRoute("MyRoute", "{controller}/{action}",
                    new { controller = "Home", action = "Index" });

            // ~/Public/Home/Index
            routes.MapRoute("", "Public/{controller}/{action}",
                new { controller = "Home", action = "Index" });
        }
    }
}
