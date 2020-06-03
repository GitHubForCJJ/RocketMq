using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ.RocketMq.Models
{
    /// <summary>
    /// 待消费的消息
    /// </summary>
    public class ConsumerMsg
    {
        /// <summary>
        /// 消息id
        /// </summary>
        public string MessageId { set; get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 消息产生时间
        /// </summary>
        public DateTime BornTimes { get; set; }
    }
}
