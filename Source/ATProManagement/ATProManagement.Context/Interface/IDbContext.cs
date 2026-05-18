using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Context
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<T> Repo<T>() where T : class;
    }
}
