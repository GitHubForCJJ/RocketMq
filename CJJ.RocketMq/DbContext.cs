using System;
using System.Collections.Generic;
using CJJ.RocketMq.Common;
using SqlSugar;

namespace CJJ.RocketMq
{
    internal class DbContext
    {
        public DbContext()
        {
            //CommonDb.Aop.OnLogExecuting = (sql, pars) =>
            //{
            //    Go.Log.Core.Log.LogManager.Info("OnLogExecuting", new { sql, pars }.SerializeObject());
            //};
        }

        public SqlSugarClient CommonDb => _lazyCommonDb.Value;

        /// <summary>
        /// 如果配置了 SlaveConnectionConfigs那就是主从模式,所有的写入删除更新都走主库，查询走从库，事务内都走主库，HitRate表示权重 值越大执行的次数越高，如果想停掉哪个连接可以把HitRate设为0
        /// </summary>
        private readonly Lazy<SqlSugarClient> _lazyCommonDb = new Lazy<SqlSugarClient>(() => new SqlSugarClient(new ConnectionConfig
        {
            ConnectionString = Config.GetCommonWriteDbStr(),
            DbType = DbType.MySql,
            InitKeyType = InitKeyType.SystemTable,
            IsAutoCloseConnection = true,
            SlaveConnectionConfigs = new List<SlaveConnectionConfig>
            {
                new SlaveConnectionConfig() { HitRate=100, ConnectionString= Config.GetCommonReadDbStr() }
            }
        }));
    }

    internal class DbContext<T> : DbContext where T : class, new()
    {
        public SimpleClient<T> CurrentDb => new SimpleClient<T>(CommonDb);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return CurrentDb.GetList();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }
    }
}
