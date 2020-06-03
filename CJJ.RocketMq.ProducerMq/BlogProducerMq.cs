using CJJ.RocketMq.Models;
using CJJ.RocketMq.Producer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ.RocketMq.ProducerMq
{
    public class BlogProducerMq
    {

        /// <summary>
        /// 消息发送类
        /// </summary>
        BlogMsg model = null;

        /// <summary>
        /// 消息发送类
        /// </summary>
        List<BlogMsg> modelList = null;

        /// <summary>
        /// 消息发送逻辑类
        /// </summary>
        RocketProducer mqPrbll = null;


        public BlogProducerMq()
        { }
        /// <summary>
        /// 发送消息到消息队列
        /// 构造方法
        /// <param name="model">消息对象</param>
        /// </summary>
        public BlogProducerMq(BlogMsg param)
        {

            this.model = param;
            mqPrbll = new RocketProducer(6, "Go_MicroShop_User_ShopUserStatistic");
        }


        /// <summary>
        /// 发送消息
        /// 此方法调用要求消息实体在构造方法时即传入，
        /// 否则会报消息为空异常
        /// </summary>
        /// <returns></returns>
        public Result Send()
        {
            if (model == null || string.IsNullOrEmpty(model.Blogid))
                throw new Exception("ProducerMq.Send()入参为空" + JsonConvert.SerializeObject(model));
            return this.Send(JsonConvert.SerializeObject(model));
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息本身</param>
        /// <param name="key">消息队列key(非必传)</param>
        /// <returns></returns>
        public virtual Result Send(string message, string key = "")
        {
            Result res = new Result();
            try
            {
                if (string.IsNullOrWhiteSpace(message))
                    throw new Exception("ProducerMq入参message为空");
                Console.WriteLine("生产者发消息" + message);
                res = mqPrbll.Send(message, key);
            }
            catch (Exception ex)
            {
                //LogManager.Exception(ex, "ProducerMq.Send(string message, string key)", message, res);
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
