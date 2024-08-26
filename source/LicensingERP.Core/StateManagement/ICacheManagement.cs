using System.Web;
using System;
using Microsoft.Extensions.Caching.Memory;

namespace LicensingERP.StateManagement
{
    public interface ICacheManagement : IDisposable
    {
        IMemoryCache SetCache<T>(T CacheValue, string CacheKey, int ExpirationTime) where T : new();
        T GetCache<T>(string CacheKey) where T : new();
        bool CacheAvailable<T>(string CacheKey) where T : new();
    }
}
