using SecurityServicesLogging.Business.Model;
using System.Linq.Expressions;

namespace SecurityServicesLogging.Business.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task InsertRange(List<T> entity);
        Task<List<T>> GetAll();
        Task<List<T>> GetQuery(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}
