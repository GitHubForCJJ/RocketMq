using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ.RocketMq.Models
{
    public class BlogMsg
    {
        /// <summary>
        /// 商家用户id
        /// </summary>
        public string Blogid { get; set; }

        /// <summary>
        /// 参数类型 1=时间  2=数量  3=小数类型(decimal)
        /// </summary>
        public int Type { get; set; }

    }
}
