using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace alodc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ProductUser", action = "Index2", id = UrlParameter.Optional }
            );*/
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { area = "User", controller = "ProductUser", action = "Index2", id = UrlParameter.Optional }, // Parameter defaults
                new[] { "alodc.Areas.ProductUser.Controllers" }
            ).DataTokens.Add("area", "User");


            /*routes.MapRoute(
                "Admin", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { area = "Admin", controller = "CategoriesAdmin", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new[] { "alodc.Areas.CategoriesAdmin.Controllers" }
            ).DataTokens.Add("area", "Admin");*/

            /*routes.MapRoute(
               name: "Admin", // Route name
               url: "{controller}/{action}/{id}", // URL with parameters
               defaults: new
               {
                   controller = "ProductAdmin1",
                   action = "Index",
                   id = UrlParameter.Optional
               },
               namespaces: new[]
               {
                   "alodc.Controllers"
               }

               );*/


        }

    }
}
