using CJJ.RocketMq;
using CJJ.RocketMq.Models;

namespace CJJ.RocketMq
{
    internal class MqRouteLogic : DbContext<MqRoute>
    {
        internal MqRoute GetRoute(string machId, string programId, int type, int bizId, string subBiz)
        {
            return CommonDb.Queryable<MqRoute>().Where(p =>
             p.MachineIdent == machId
             && p.ProgramIdent == programId
             && p.Type == type
             && p.BusinessId == bizId
             && p.SubBusiness == subBiz
             && p.IsDelete == 0).First();
        }
    }
}
