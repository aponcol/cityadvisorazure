using System.Web.Mvc;
using System.Web.Routing;

namespace CityAdvisor
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{q}",
            //    defaults: new { controller = "Suggestions", action = "Main", q = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Suggestions",
                url: "suggestions/{q}",
                defaults: new { controller = "Suggestions", action = "Index", q = UrlParameter.Optional }
            );
        }
    }
}
