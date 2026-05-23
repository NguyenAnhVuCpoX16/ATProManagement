using ATProManagement.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Base
{
    public interface IMyDbFactory
    {
        IDbContext CreateDbContext();
    }
}
