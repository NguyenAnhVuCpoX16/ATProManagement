using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ATProManagement.Db
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext _db;

        protected DbSet<T> DbSet => _db.Set<T>();

        public Repository(DbContext db)
        {
            _db = db;
        }

        public IQueryable<T> Query()
        {
            return _db.Set<T>();
        }


        public virtual async Task<T?> FindAsync(object id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _db.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public virtual Task<IList<T>> GetList()
        {
            throw new NotImplementedException();
        }

        public virtual Task<IList<T>> GetList(Expression<Func<T, bool>>? filter)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Exists(Expression<Func<T, bool>> filter)
        {
            return await this.Query().AnyAsync(filter);
        }

        public virtual async Task Insert(T entity, bool commit = true)
        {
            await DbSet.AddAsync(entity);
            if (commit)
            {
                await _db.SaveChangesAsync();
            }
        }

        public async Task<T?> GetOneEdit(Expression<Func<T, bool>>? filter)
        {
            if (filter == null)
                return default;
            return await this.DbSet.Where(filter).FirstOrDefaultAsync();
        }
        public virtual async Task Remove(T entity, bool commit = true)
        {

            DbSet.Remove(entity);

            if (commit)
            {
                await _db.SaveChangesAsync();
            }
        }

        public async Task<T?> GetOne(Expression<Func<T, bool>>? filter)
        {
            if (filter == null)
                return default;
            return await this.Query().Where(filter).FirstOrDefaultAsync();
        }

        public virtual async Task InsertRange(params T[] entities)
        {
            DbSet.AddRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
