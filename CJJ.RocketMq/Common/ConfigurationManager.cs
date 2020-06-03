using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace CJJ.RocketMq.Common
{
    internal class ConfigurationManager
    {
        private readonly static IConfiguration _configuration = null;
        private static ConcurrentDictionary<string, object> _cacheDic = new ConcurrentDictionary<string, object>();

        static ConfigurationManager()
        {
            try
            {
                _configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                    .Build();

                ChangeToken.OnChange(() => _configuration.GetReloadToken(), () =>
                {
                    if (_cacheDic.Any())
                    {
                        _cacheDic = new ConcurrentDictionary<string, object>();
                    }
                });
            }
            catch (Exception e)
            {
                _configuration = null;
            }
        }

        public static T GetAppSettings<T>(string key) where T : class, new()
        {
            if (_configuration == null)
            {
                return default(T);
            }

            if (_cacheDic.ContainsKey(key))
            {
                var val = _cacheDic[key];
                if (val != null)
                {
                    return (T)val;
                }
            }
            object obj = _configuration.GetSection(key).Get<T>();
            _cacheDic.TryAdd(key, obj);
            return (T)obj;
        }

        /// <summary>
        /// 获取配置文件节点的值，支持嵌套对象，key的格式类似于 RedisConfig:RedisDb:Name
        /// 【注意】此方法仅适用于获取配置文件的最后一级，即配置节点的值只能是string、int等基础类型，不能是对象
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>配置文件节点的值</returns>
        public static string GetSectionValue(string key)
        {
            if (_configuration == null)
            {
                return string.Empty;
            }
            return _configuration.GetSection(key).Value;
        }
    }
}
