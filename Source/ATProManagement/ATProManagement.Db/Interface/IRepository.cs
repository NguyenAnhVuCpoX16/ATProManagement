using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ATProManagement.Db
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Exists(Expression<Func<T, bool>> filter);

        IQueryable<T> Query();

        IQueryable<T> Query(Expression<Func<T, bool>>? filter = null);

        Task Insert(T entity, bool commit = true);

        Task<IList<T>> GetList();

        Task<IList<T>> GetList(Expression<Func<T, bool>>? filter);

        Task<T?> GetOne(Expression<Func<T, bool>>? filter);

        Task<T?> GetOneEdit(Expression<Func<T, bool>>? filter);

        Task InsertRange(params T[] entity);

        Task Remove(T entity, bool commit = true);
    }
}
