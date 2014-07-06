using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Twits
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Enable cors
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "TwitApi",
                routeTemplate: "api/Twit/{id}",
                defaults: new { controller = "apiTwit", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TweetApi",
                routeTemplate: "api/Tweet/{id}",
                defaults: new { controller = "apiTweet", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TwitFollowersApi",
                routeTemplate: "api/Twit/{id}/Followers",
                defaults: new { controller = "apiTwitFollowers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
