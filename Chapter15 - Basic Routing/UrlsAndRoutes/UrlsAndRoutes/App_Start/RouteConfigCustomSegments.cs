using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfigCustomSegments
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ~/Home/Index/{id}/{segment} - from additionalcontrollers namespace
            routes.MapRoute(
                name: "AddControllerRoute",
                url: "Home/{controller}/{action}/{id}/{*catchall}",
                defaults: 
                new 
                { 
                    controller = "Home", 
                    action = "Index",
                    id = UrlParameter.Optional 
                },
                namespaces: new [] { "UrlsAndRoutes.AdditionalControllers" });

            // ~/Home/Index/{id}/{segment}
            routes.MapRoute(
                name: "MyRoute",
                url: "Home/{controller}/{action}/{id}/{*catchall}",
                defaults:
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                namespaces: new[] { "UrlsAndRoutes.Controllers" });

            // ~/Home/Index/{id}
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }
    }
}
