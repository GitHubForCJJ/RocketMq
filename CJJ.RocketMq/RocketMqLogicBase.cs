using CJJ.RocketMq.Common;
using CJJ.RocketMq.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ.RocketMq
{
    /// <summary>
    /// 消息队列逻辑基类
    /// </summary>
    public class RocketMqLogicBase
    {
        /// <summary>
        /// 大业务id:大业务id，使用前先登记
        /// </summary>
        protected readonly int _bizId = 0;

        /// <summary>
        /// 小业务标识:子业务标识
        /// </summary>
        protected readonly string _subBiz = string.Empty;

        /// <summary>
        /// 类型(生产者/消费者):1:生产者； / 2:消费者；
        /// </summary>
        protected readonly int _type = 0;

        /// <summary>
        /// 消息队列配置相关信息
        /// </summary>
        internal readonly RocketConfigModel _configModel = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="businessId"> 大业务id:大业务id，使用前先登记</param>
        /// <param name="subBusiness">小业务标识:子业务标识</param>
        /// <param name="type">类型(生产者/消费者):1:生产者； / 2:消费者；</param>
        public RocketMqLogicBase(int businessId, string subBusiness, int type)
        {
            _bizId = businessId;
            _subBiz = subBusiness;
            _type = type;

            // 初始化消息队列所需数据
            _configModel = DataIni();
        }

        private RocketConfigModel DataIni()
        {
            RocketConfigModel res = new RocketConfigModel();
            try
            {
                //  [MachIdent]
                //  Name = WCF_24.71
                //string machId = GetMachId();
                string machId = "CJJMACHID";
                string programId = "CJJBlog_Pid";//Config.GetProgramIdent();
                //MqRoute route = new DbCache().GetRoute(machId, programId, _type, _bizId, _subBiz);
                MqRoute route = new MqRoute
                {
                    Address="192.168.20.7:9876",
                    GroupName="BlogMessage",
                    Topic= "BlogMessage",
                    Tags= "BlogMessage"
                };
                if (route == null)
                {
                    throw new Exception($"获取消息队列路由信息失败,入参【{JsonConvert.SerializeObject(new { machId, programId, _type, _bizId, _subBiz })}");
                }
                res.Group = route.GroupName;
                res.NameServerAdress = route.Address;
                res.Topic = route.Topic;
                res.Tags = route.Tags;
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"初始化消息队列配置数据异常,异常信息：{e.Message}{Environment.NewLine}，异常堆栈：{e.StackTrace}");
                throw;
            }
            return res;
        }

        //private string GetMachId()
        //{
        //    var machId = string.Empty;
        //    string path = @"C:\CJJ\Server.ini";
        //    if (!File.Exists(path))
        //    {
        //        throw new CustomException($"路径 {path} 未找到配置文件");
        //    }
        //    var allLines = File.ReadAllLines(path);
        //    if (allLines == null || !allLines.Any())
        //    {
        //        throw new CustomException($"路径 {path} 配置文件内容不正确");
        //    }
        //    foreach (var item in allLines)
        //    {
        //        if (item.StartsWith("Name"))
        //        {
        //            var tmp = item.Split("=");
        //            if (tmp == null || tmp.Length != 2)
        //            {
        //                throw new CustomException($"路径 {path} 配置文件内容不正确");
        //            }
        //            machId = tmp[1];
        //            break;
        //        }
        //    }
        //    if (machId.IsNullOrWhiteSpace())
        //    {
        //        throw new CustomException($"路径 {path} 配置文件内容不正确");
        //    }
        //    return machId;
        //}
    }
}
