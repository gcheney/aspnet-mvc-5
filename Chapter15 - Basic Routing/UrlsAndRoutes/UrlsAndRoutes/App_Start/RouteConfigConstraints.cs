using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;

using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfigConstraints
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ~/Home/Index - only in chrome 
            //Added constraints
            routes.MapRoute(
                name: "ChromeRoute",
                url: "{*catchall}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { customContsraint = new UserAgentConstraint("Chrome")},
                namespaces: new[] { "UrlsAndRoutes.AdditionalControllers" }
            );

            // ~/Home/Index|About/{id(only alpha and at least 6 letters)}/{segment} - only GET Request
            //Added constraints
            routes.MapRoute(
                name: "MyRoute",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults:
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                constraints:
                new
                {
                    controller = "^H.*",
                    action = "Index|About",
                    httpMethod = new HttpMethodConstraint("GET"),
                    id = new CompoundRouteConstraint(new IRouteConstraint []
                    {
                        new AlphaRouteConstraint(),
                        new MinLengthRouteConstraint(6)
                    })
                },
                namespaces: new[] { "UrlsAndRoutes.Controllers" }
            );
        }
    }
}
