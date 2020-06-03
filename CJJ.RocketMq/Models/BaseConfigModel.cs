namespace CJJ.RocketMq.Models
{
    /// <summary>
    /// 基础的配置文件model
    /// </summary>
    internal class BaseConfigModel
    {
        /// <summary>
        /// 程序id
        /// </summary>
        public string ProgramIdent { get; set; }

        /// <summary>
        /// 公共数据库写链接（AES加密）
        /// </summary>
        public string CommonDBWrite { get; set; }

        /// <summary>
        /// 公共数据库读链接（AES加密）
        /// </summary>
        public string CommonDBRead { get; set; }
    }
}
