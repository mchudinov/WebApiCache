using System.Net.Http.Headers;
using System.Web.Http.Controllers;

namespace WebApiCache
{
    public class CustomCacheKeyGenerator : WebApi.OutputCache.V2.DefaultCacheKeyGenerator
    {
        public override string MakeCacheKey(HttpActionContext actionContext, MediaTypeHeaderValue header, bool excludeQueryString = false)
        {
            return base.MakeCacheKey(actionContext, header, excludeQueryString);
        }
    }
}
