using Microsoft.EntityFrameworkCore;
using SecurityServicesLogging.Business.Interfaces;
using SecurityServicesLogging.Business.Model;
using System.Linq.Expressions;
using static SecurityServicesLogging.Repository.Context.DBContext;

namespace SecurityServicesLogging.Repository.repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly ApplicationDbContext _dataBase;
        protected readonly DbSet<T> _dataBaseSet;

        protected Repository(ApplicationDbContext db)
        {
            _dataBase = db;
            _dataBaseSet = db.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dataBaseSet.ToListAsync();
        }

        public async Task<List<T>> GetQuery(Expression<Func<T, bool>> predicate)
        {
            return await _dataBaseSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task InsertRange(List<T> entity)
        {
            _dataBaseSet.AddRange(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _dataBase.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dataBase?.Dispose();
        }
    }
}
