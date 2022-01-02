using ParkingSystem.Business.Interface.Core.Caching.DTO;
using ParkingSystem.Business.Interface.Core.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Business.Interface.Core.Caching.Managers
{
    interface ICachingManager : IBusinessManager
    {
        T Get<T>(string cacheKey, Func<T> fallback, CachingOptions options) where T : class;
        void Remove(string key, CacheType cacheType);
        void RemoveAll(CacheType cacheType);
    }
}
