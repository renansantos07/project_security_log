using SecurityServicesLogging.Business.Interfaces;
using SecurityServicesLogging.Business.Model;
using SecurityServicesLogging.Repository.Context;
using System.Linq.Expressions;

namespace SecurityServicesLogging.Repository.repository
{
    public class SecurityLogRepository : Repository<SecurityLog>, ISecurityLogRepository
    {
        public SecurityLogRepository(DBContext.ApplicationDbContext db) : base(db)
        {
        }

        public bool AnyQuery(Expression<Func<SecurityLog, bool>> predicate)
        {
            return _dataBaseSet.Any(predicate);
        }
    }
}
