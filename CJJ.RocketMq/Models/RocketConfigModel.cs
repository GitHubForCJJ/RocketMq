namespace CJJ.RocketMq.Models
{
    /// <summary>
    /// 消息队列所需参数
    /// </summary>
    internal class RocketConfigModel
    {
        /// <summary>
        /// 主题
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// 组
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// NameServer的地址
        /// </summary>
        public string NameServerAdress { get; set; }

        /// <summary>
        /// 标签(集合):多个用||隔开
        /// </summary>
        public string Tags { get; set; }
    }
}
