﻿using System;
using CacheManager.Core;

namespace Cache
{
    public class CacheManagerProvider : CacheProviderBase<ICacheManager<object>>
    {    
        protected override ICacheManager<object> InitCache()
        {
            return CacheFactory.FromConfiguration<object>("Redis");
        }

        public override T Get<T>(string key)
        {
            return Cache.Get<T>(KeyPrefix+key);
        }

        public override void Set<T>(string key, T value, int duration)
        {
            Cache.Put(KeyPrefix+key, value);
            Cache.Expire(KeyPrefix+key, DateTime.Now.AddMinutes(duration));
        }

        public override void SetSliding<T>(string key, T value, int duration)
        {
            Cache.Put(KeyPrefix+key, value);
            Cache.Expire(KeyPrefix+key, new TimeSpan(0, duration, 0));
        }

        public override void Set<T>(string key, T value, DateTimeOffset expiration)
        {
            Cache.Put(KeyPrefix + key, value);
            Cache.Expire(KeyPrefix + key, expiration);
        }

        public override bool Exists(string key)
        {
            return Cache.Exists(KeyPrefix+key);
        }

        public override void Remove(string key)
        {
            Cache.Remove(KeyPrefix+key);
        }        
    }
}
