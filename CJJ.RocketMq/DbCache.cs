using System;
using CJJ.RocketMq.Models;

namespace CJJ.RocketMq
{
    internal class DbCache
    {
        internal MqRoute GetRoute(string machId, string programId, int type, int bizId, string subBiz)
        {
            var key = $"{machId}_{programId}_{bizId}_{subBiz}_{type}";
            var res = Common.MemoryCacheHelper.Get<MqRoute>(key);
            if (res != null && res.ID > 0)
            {
                return res;
            }
            res = new MqRouteLogic().GetRoute(machId, programId, type, bizId, subBiz);
            if (res != null && res.ID > 0)
            {
                Common.MemoryCacheHelper.Set<MqRoute>(key, res, DateTime.Now.AddMinutes(60));
            }
            return res;
        }
    }
}
