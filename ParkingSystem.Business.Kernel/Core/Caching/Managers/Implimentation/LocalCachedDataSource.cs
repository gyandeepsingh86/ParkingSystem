using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Caching;

namespace ParkingSystem.Business.Kernel.Core.Caching.Managers.Implimentation
{
    class LocalCachedDataSource : ICachedDataSource
    {
        private IMemoryCache _cache;

        public LocalCachedDataSource(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public T RetrieveCachedData<T>(string cacheKey, Func<T> fallback, CacheItemPolicy policy) where T : class
        {
            var item = _cache.Get(cacheKey) as T;
            if (item == null)
            {
                item = fallback();
                if (item != null)
                {
                    if (policy == null)
                        _cache.Set(cacheKey, item);
                    else
                        _cache.Set(cacheKey, item, policy.AbsoluteExpiration.DateTime);
                }
            }
            return item;
        }

        public void RemoveCachedData(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        public void ClearAll()
        {
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(_cache) as ICollection;
            var items = new List<string>();
            if (collection != null)
                foreach (DictionaryEntry item in collection)
                {
                    var key = item.Key as string;
                    if (key != null)
                        RemoveCachedData(key);
                }
        }
    }
}
