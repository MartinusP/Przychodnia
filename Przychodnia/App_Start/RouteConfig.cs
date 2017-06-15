using System.Web.Mvc;
using System.Web.Routing;

namespace Przychodnia
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

            routes.MapRoute(
               "Home",
               "Home/",
               new { controller = "Home", action = "Index" }
           );

            routes.MapRoute(
               "Dyzur",
               "Dyzur/",
               new { controller = "Dyzur", action = "Index" }
           );

            routes.MapRoute(
               "Oddzial",
               "Oddzial/",
               new { controller = "Oddzial", action = "Index" }
           );

            routes.MapRoute(
               "Pacjent",
               "Pacjent/",
               new { controller = "Pacjent", action = "Index" }
           );

            routes.MapRoute(
               "Placowka",
               "Placowka/",
               new { controller = "Placowka", action = "Index" }
           );

            routes.MapRoute(
               "Pracownik",
               "Pracownik/",
               new { controller = "Pracownik", action = "Index" }
           );

            routes.MapRoute(
               "Recepta",
               "Recepta/",
               new { controller = "Recepta", action = "Index" }
           );

            routes.MapRoute(
               "Sala",
               "Sala/",
               new { controller = "Sala", action = "Index" }
           );

            routes.MapRoute(
               "Specjalizacja",
               "Specjalizacja/",
               new { controller = "Specjalizacja", action = "Index" }
           );

            routes.MapRoute(
               "Wizyta",
               "Wizyta/",
               new { controller = "Wizyta", action = "Index" }
           );
        }
    }
}