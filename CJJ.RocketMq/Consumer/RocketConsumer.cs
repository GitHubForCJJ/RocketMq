using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewLife.Common;
using NewLife.IO;
using CJJ.RocketMq.Models;

namespace CJJ.RocketMq.Consumer
{
    /// <summary>
    /// 消费者
    /// </summary>
    public class RocketConsumer : RocketMqLogicBase
    {
        private readonly NewLife.RocketMQ.Consumer _consumer = null;

        /// <summary>
        /// 消息到达后的处理事件
        /// </summary>
        public Func<ConsumerMsg, Boolean> OnConsume = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="businessId"> 大业务id:大业务id，使用前先登记</param>
        /// <param name="subBusiness">小业务标识:子业务标识</param>
        public RocketConsumer(int businessId, string subBusiness) : base(businessId, subBusiness, 2)
        {
            _consumer = new NewLife.RocketMQ.Consumer()
            {
                Topic = _configModel.Topic,
                NameServerAddress = _configModel.NameServerAdress,
                Group = _configModel.Group,
                FromLastOffset = true,
                SkipOverStoredMsgCount = 0,
                BatchSize = 1,
            };
        }

        /// <summary>
        /// 开始监听、处理消费信息
        /// </summary>
        public void Start()
        {
            if (OnConsume == null)
            {
                throw new Exception("您还未注册消息处理事件");
            }
            _consumer.OnConsume = (q, ms) =>
            {
                var successCnt = 0;
                foreach (var item in ms.ToList())
                {
                    var handleRes = OnConsume(new ConsumerMsg() { Key = item.Keys, Message = item.Body.ToStr(), MessageId = item.MsgId, BornTimes = item.BornTimestamp.ToDateTime() });
                    if (handleRes)
                    {
                        successCnt++;
                    }
                }
                return successCnt >= ms.Length;
            };
            _consumer.Start();
        }
    }
}
