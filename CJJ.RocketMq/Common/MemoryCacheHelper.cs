using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CJJ.RocketMq.Common
{
    internal static class MemoryCacheHelper
    {
        private static IMemoryCache _memoryCache = new MemoryCache(Options.Create(new MemoryCacheOptions()));

        internal static T Get<T>(string key)
        {
            try
            {
                var isExist = _memoryCache.TryGetValue(key, out var val);
                if (isExist)
                {
                    return (T)val;
                }
                return default(T);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        internal static void Set<T>(string key, T obj)
        {
            _memoryCache.GetOrCreate(key, (cacheEntry => obj));
        }

        internal static void Set<T>(string key, T obj, TimeSpan timeSpan)
        {
            _memoryCache.GetOrCreate(key, (cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(timeSpan);
                return obj;
            }));
        }

        internal static void Set<T>(string key, T obj, DateTime expireTime)
        {
            _memoryCache.GetOrCreate(key, (cacheEntry =>
            {
                cacheEntry.SetAbsoluteExpiration(expireTime);
                return obj;
            }));
        }

        internal static void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        internal static void Clear()
        {
            _memoryCache = new Microsoft.Extensions.Caching.Memory.MemoryCache(Options.Create(new MemoryCacheOptions()));
        }
    }
}
