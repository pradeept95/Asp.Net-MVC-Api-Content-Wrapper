using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContentWrapperExample.MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            config.Filters.Add(new Api.Helper.ContentWrapper.MVC.Filters.ApiExceptionFilter());
            config.Filters.Add(new Api.Helper.ContentWrapper.MVC.Filters.ValidateModelStateAttribute());
            config.MessageHandlers.Add(new Api.Helper.ContentWrapper.MVC.WrappingHandler());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
