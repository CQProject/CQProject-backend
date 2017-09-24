using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CQPROJ.Presentation.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            var corsAttr = new EnableCorsAttribute(origins: "http://localhost:4200", headers: "Content-Type, Authorization", methods: "GET, POST, PUT, DELETE");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();
            
        }
    }
}
