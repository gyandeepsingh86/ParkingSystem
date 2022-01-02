using ParkingSystem.Business.Kernel.Core.Factory.Unity;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Unity;

namespace ParkingSystem.Business.Kernel.Core.Caching.Managers.Implimentation
{
    class DistributedCachedDataSource : ICachedDataSource
    {
        public T RetrieveCachedData<T>(string cacheKey, Func<T> fallback, CacheItemPolicy policy) where T : class
        {
            var objectCache = UnityContainerFactory.Instance.Resolve<ObjectCache>();
            var item = objectCache.Get(cacheKey) as T;
            if (item == null)
            {
                item = fallback();
                if (item != null)
                    objectCache.Add(new CacheItem(cacheKey, item, null), policy);
            }
            return item;
        }

        public void RemoveCachedData(string cacheKey)
        {
            var objectCache = UnityContainerFactory.Instance.Resolve<ObjectCache>();
            objectCache.Remove(cacheKey);
        }


        public void ClearAll()
        {
            var objectCache = UnityContainerFactory.Instance.Resolve<ObjectCache>();
            foreach (KeyValuePair<string, object> pair in objectCache)
            {
                RemoveCachedData(pair.Key);
            }
        }
    }
}
