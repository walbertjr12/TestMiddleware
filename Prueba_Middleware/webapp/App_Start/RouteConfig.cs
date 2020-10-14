#region Using

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace SmartAdminMvc
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Departamentos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}