using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using UniversalTestingService.Filters;

namespace UniversalTestingService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Api",
                routeTemplate: "api/{controller}",
                defaults: new { }
            );

            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { },
                constraints: new
                {
                    id = new MinRouteConstraint(1),
                }
            );

            config.Filters.Add(new HandlingExceptionAttribute());
        }
    }
}
