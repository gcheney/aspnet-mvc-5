using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //ignore files or routes
            routes.IgnoreRoute("Content/{filename}.html");

            routes.RouteExistingFiles = true;
            // change preCondition="managedHandler,runtimeVersionv4.0" in IIS config to hide 
            //static content files that dont match routes

            routes.MapMvcAttributeRoutes();

            //Route to disk files - after IIS change
            routes.MapRoute("DiskFiles", "Content/StaticContent.html",
                new { controller = "Customer", action = "List" });

            //routes.Add(new Route("SayHello", new CustomRouteHandler()));

            routes.Add(new LegacyRoute(
                "~/articles/Windows_3.1_Overview.html",
                "~/old/.NET_1.0_Class_Library"));

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "UrlsAndRoutes.Controllers"}
            );

            routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" },
                new[] { "UrlsAndRoutes.Controllers" });
        }
    }
}
