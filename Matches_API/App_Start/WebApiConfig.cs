using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Matches_API.BLL.Helpers;



namespace Matches_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //  NinjectModule registration = new NInjectRegistrations();
            //var kernel = new StandardKernel(registration);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
