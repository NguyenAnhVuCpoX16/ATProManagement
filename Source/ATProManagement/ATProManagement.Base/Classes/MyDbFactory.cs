using ATProManagement.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Base
{
    public class MyDbFactory : IMyDbFactory
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public MyDbFactory(DbContextOptions<AppDbContext> options)
        {
            _options = options;
        }
        public IDbContext CreateDbContext()
        {
            return new AppDbContext(_options);
        }
    }
}
