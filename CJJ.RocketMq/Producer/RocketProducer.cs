using System;
using CJJ.RocketMq.Models;
using NewLife.Extension;
using NewLife.Serialization;

namespace CJJ.RocketMq.Producer
{
    /// <summary>
    /// 生产者
    /// </summary>
    public class RocketProducer : RocketMqLogicBase
    {
        /// <summary>
        /// 生产者
        /// </summary>
        private NewLife.RocketMQ.Producer _producer = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="businessId"> 大业务id:大业务id，使用前先登记</param>
        /// <param name="subBusiness">小业务标识:子业务标识</param>
        public RocketProducer(int businessId, string subBusiness) : base(businessId, subBusiness, 1)
        {
            _producer = new NewLife.RocketMQ.Producer()
            {
                Topic = _configModel.Topic,
                NameServerAddress = _configModel.NameServerAdress,
                Group = _configModel.Group,
            };
            _producer.Start();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="key">key</param>
        /// <param name="msgDelayLevel">消息延迟等级，0=不延迟，具体各等级对应的延迟时间参考消息队列服务端的属性配置文件【messageDelayLevel】，默认为 1s 5s 10s 30s 1m 2m 3m 4m 5m 6m 7m 8m 9m 10m 20m 30m 1h 2h</param>
        /// <returns>发送结果</returns>
        public Result Send(Object message, string key = "", int msgDelayLevel = 0)
        {
            Result res = new Result();
            try
            {
                if (!(message is Byte[] buf))
                {
                    if (!(message is String str)) str = message.ToJson();

                    buf = str.GetBytes();
                }

                NewLife.RocketMQ.Protocol.Message msg = new NewLife.RocketMQ.Protocol.Message() { Body = buf, Tags = _configModel.Tags, Keys = key, DelayTimeLevel = msgDelayLevel };
                var sendRes = _producer.Publish(msg);
                res.IsSucceed = sendRes.Status == NewLife.RocketMQ.Protocol.SendStatus.SendOK;
            }
            catch (System.Exception e)
            {
                res.Message = e.Message;
            }
            return res;
        }
    }
}
