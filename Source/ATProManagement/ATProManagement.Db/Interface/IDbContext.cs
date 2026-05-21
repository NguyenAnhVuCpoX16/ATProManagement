using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Db
{
    public interface IDbContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<T> Repo<T>() where T : class;
    }
}
