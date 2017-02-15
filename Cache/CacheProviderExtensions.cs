﻿using System;
using System.Threading.Tasks;

namespace Cache
{
    public static class CacheProviderExtensions
    {
        public static async Task<T> UseCached<T>(this ICacheProvider cache, string key, Func<Task<T>> factory, int? duration = null) where T: class
        {
            var cached = cache.Get<T>(key);
            if (cached != null)
            {
                return cached;
            }

            var value = await factory();
            if (duration.HasValue)
            {
                cache.Set(key, value, duration.Value);
            }
            else
            {
                cache.Set(key, value);
            }

            return value;
        }
    }
}
