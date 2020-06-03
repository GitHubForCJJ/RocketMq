using CJJ.RocketMq.Models;

using System;

namespace CJJ.RocketMq.Common
{
    internal class Config
    {
        /// <summary>
        /// 路由库写连接
        /// </summary>
        /// <returns></returns>
        public static string GetCommonWriteDbStr()
        {
            var val = ConfigurationManager.GetAppSettings<BaseConfigModel>("RocketBaseConfig");
            if (val == null || val.CommonDBWrite.IsNullOrEmpty())
            {
                throw new System.Exception("消息队列配置信息错误");
            }
            return val.CommonDBWrite;
        }

        /// <summary>
        /// 路由库读连接
        /// </summary>
        /// <returns></returns>
        public static string GetCommonReadDbStr()
        {
            var val = ConfigurationManager.GetAppSettings<BaseConfigModel>("RocketBaseConfig");
            if (val == null || val.CommonDBRead.IsNullOrEmpty())
            {
                throw new Exception("消息队列配置信息错误");
            }
            return val.CommonDBRead;
        }

        /// <summary>
        /// 程序标识
        /// </summary>
        /// <returns></returns>
        public static string GetProgramIdent()
        {
            var val = ConfigurationManager.GetAppSettings<BaseConfigModel>("RocketBaseConfig");
            if (val == null || val.ProgramIdent.IsNullOrEmpty())
            {
                throw new Exception("消息队列配置信息错误");
            }
            return val.ProgramIdent;
        }
    }
}
