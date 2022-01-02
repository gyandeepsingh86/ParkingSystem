using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace ParkingSystem.Business.Kernel.Core.Caching.Managers
{
    /// <summary>
    /// Cached Data Source
    /// </summary>
    interface ICachedDataSource
    {
        /// <summary>
        /// Retrieves the cached data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="fallback">The fallback.</param>
        /// <param name="policy">The policy.</param>
        /// <returns></returns>
        T RetrieveCachedData<T>(string cacheKey, Func<T> fallback, CacheItemPolicy policy) where T : class;

        /// Removes the cached data.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        void RemoveCachedData(string cacheKey);

        void ClearAll();
    }
}
