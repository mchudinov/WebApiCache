﻿using System;
using System.Configuration;

namespace Cache
{
    public abstract class CacheProviderBase<TCache> : ICache
    {
        public int CacheDuration { get; set; }

        protected TCache Cache;

        private const int DefaultCacheDurationMinuts = 30;

        protected readonly string KeyPrefix;

        public CacheProviderBase()
        {
            int result;
            CacheDuration = int.TryParse(ConfigurationManager.AppSettings["CacheDefaultDurationMinutes"], out result) ? result : DefaultCacheDurationMinuts;
            KeyPrefix = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["CacheKeyPrefix"]) ? ConfigurationManager.AppSettings["CacheKeyPrefix"] : string.Empty;
            Cache = InitCache();
        }

        protected abstract TCache InitCache();

        public abstract T Get<T>(string key);

        public virtual void Set<T>(string key, T value)
        {
            Set<T>(key, value, CacheDuration);
        }

        public virtual void SetSliding<T>(string key, T value)
        {
            SetSliding<T>(key, value, CacheDuration);
        }

        public abstract void Set<T>(string key, T value, int duration);

        public abstract void SetSliding<T>(string key, T value, int duration);

        public abstract void Set<T>(string key, T value, DateTimeOffset expiration);

        public abstract bool Exists(string key);

        public abstract void Remove(string key);
    }
}
