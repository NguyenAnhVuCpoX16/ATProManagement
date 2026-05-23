using ATProManagement.Base;
using ATProManagement.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ATProManagement.Context
{
    public class MyContext : IMyContext
    {
        private readonly IDbContext _db;
        private readonly IServiceProvider _provider;
        private readonly IMyDbFactory _factory;
        public MyContext(IDbContext db, IServiceProvider provider, IMyDbFactory factory)
        {
            _db = db;
            _provider = provider;
            _factory = factory;
        }

        public IDbContext ConnectDb()
        {
            return _factory.CreateDbContext();
        }

        public T GetService<T>() 
        {
            return _provider.GetService<T>();
        }
    }
}
