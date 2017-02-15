using System.Web.Http;
using Owin;
using WebApi.OutputCache.V2;

namespace WebApiCache
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.CacheOutputConfiguration().RegisterCacheOutputProvider(() => new CustomCacheProvider());

            config.CacheOutputConfiguration().RegisterDefaultCacheKeyGeneratorProvider(() => new CustomCacheKeyGenerator());

            app.UseWebApi(config);
        }
    }
}