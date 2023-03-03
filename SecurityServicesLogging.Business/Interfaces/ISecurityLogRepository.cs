using SecurityServicesLogging.Business.Model;
using System.Linq.Expressions;

namespace SecurityServicesLogging.Business.Interfaces
{
    public interface ISecurityLogRepository : IRepository<SecurityLog>
    {
        bool AnyQuery(Expression<Func<SecurityLog, bool>> predicate);
    }
}
