using System;
using System.Web;
using Microsoft.Extensions.Caching.Memory;

namespace LicensingERP.StateManagement
{
    public class CacheManagement : ICacheManagement
    {
        private IMemoryCache _cache;

        public CacheManagement(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public IMemoryCache SetCache<T>(T CacheValue, string CacheKey = null, int ExpirationTime = 60) where T : new()
        {
            try
            {
                //New development of datetime
                _cache.Set<T>(GetCacheKey<T>(CacheKey), CacheValue,
                    GenericLogic.IstNow);

                //_cache.Set<T>(GetCacheKey<T>(CacheKey), CacheValue, 
                //    DateTime.UtcNow.AddHours(5.5).AddMinutes(ExpirationTime));


                //_Context.Cache.Insert(GetCacheKey<T>(CacheKey), 
                //    CacheValue, null, 
                //    DateTime.UtcNow.AddHours(5.5).AddMinutes(ExpirationTime), 
                //    TimeSpan.Zero);
                return _cache;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetCache<T>(string CacheKey = null) where T : new()
        {
            T Tobj = default(T);
            try
            {
                if (CacheAvailable<T>(CacheKey))
                    return (T)_cache.Get<T>(GetCacheKey<T>(CacheKey));
                else
                    return Tobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CacheAvailable<T>(string CacheKey = null) where T : new()
        {
            DateTime cacheEntry;
            return _cache.TryGetValue(GetCacheKey<T>(CacheKey), out cacheEntry);// != null;
        }

        private static string GetCacheKey<T>(string CacheKey) where T : new()
        {
            if (string.IsNullOrEmpty(CacheKey))
                return new T().GetType().Name + "Cache";
            else
                return CacheKey;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
