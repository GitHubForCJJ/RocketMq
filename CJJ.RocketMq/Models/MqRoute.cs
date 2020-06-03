using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace CJJ.RocketMq.Models
{
    ///<summary>
    ///消息队列路由表:
    ///</summary>
    [SugarTable("mq_route")]
    internal partial class MqRoute
    {
        /// <summary>
        /// 
        /// </summary>
        public MqRoute()
        {
        }

        /// <summary>
        /// Desc:ID:自增id
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        /// <summary>
        /// Desc:机器标识:服务器唯一标识(取c:\Server.ini文件MacIdent大节点)
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string MachineIdent { get; set; }

        /// <summary>
        /// Desc:程序标识:程序配置文件中取值(ProgramIdent)
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string ProgramIdent { get; set; }

        /// <summary>
        /// Desc:大业务id:大业务id，使用前先登记
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int BusinessId { get; set; }

        /// <summary>
        /// Desc:小业务标识:子业务标识
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string SubBusiness { get; set; }

        /// <summary>
        /// Desc:类型(生产者/消费者):1:生产者； / 2:消费者；
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public byte Type { get; set; }

        /// <summary>
        /// Desc:组名（生产者组名/消费者组名):ProducerGroupNam/ / ConsumerGroupNam
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string GroupName { get; set; }

        /// <summary>
        /// Desc:主题
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Topic { get; set; }

        /// <summary>
        /// Desc:标签(集合):多个用||隔开
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Tags { get; set; }

        /// <summary>
        /// Desc:地址(域名或ip):ip+端口/或域名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Address { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:1900-01-01 00:00:00
        /// Nullable:False
        /// </summary>           
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Desc:修改时间:时间戳(CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)
        /// Default:CURRENT_TIMESTAMP
        /// Nullable:False
        /// </summary>           
        public DateTime ModifyTime { get; set; }

        /// <summary>
        /// Desc:删除标记:0:正常; / 1:删除; / 2:特殊
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public byte IsDelete { get; set; }

    }
}
