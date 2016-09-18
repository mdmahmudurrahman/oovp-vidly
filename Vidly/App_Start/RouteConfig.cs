using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "MoviesByReleaseDate",
                "Movies/Released/{year}/{month}",
                new { Controller = "Movies", action = "ByReleaseDate"},
                new { year = @"\d{4}", month = @"\d{2}"}
              //  new { year = @"2015|2016", month = @"\d{2}" } // only for 2015 or 2016
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
