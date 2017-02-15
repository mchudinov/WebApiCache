using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace WebApiCache
{
    [AutoInvalidateCacheOutput]
    [CacheOutput(ServerTimeSpan = 60)]
    public class CacheController : ApiController
    {
        // GET api/cache         
        public IEnumerable<string> Get()
        {
            Console.WriteLine("return from method");
            return new[] { "value1", "value2" };
        }

        public void Post(object obj)
        {
            //
        }
    }
}
