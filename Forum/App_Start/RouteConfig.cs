using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Forum",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
                );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Forum", action = "List", category = (string)null },
                constraints: new { page = @"\d+" }
                );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Forum", action = "List", page = 1 }
                );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Forum", action = "List" },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
