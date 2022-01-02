using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace ParkingSystem.Business.Interface.Core.Caching.DTO
{
    class CachingOptions
    {
        public CacheType CacheType { get; set; }
        public CacheItemPolicy CachePolicy { get; set; }
    }
}
