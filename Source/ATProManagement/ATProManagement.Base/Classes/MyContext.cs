using ATProManagement.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ATProManagement.Context
{
    public class MyContext : IMyContext
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        private readonly IDbContext _db;
        public event Action<object[]> StateChanged;
        private readonly IServiceProvider _provider;
        public MyContext(IDbContext db, IServiceProvider provider, IDbContextFactory<AppDbContext> dbFactory)
        {
            _db = db;
            _provider = provider;
            _factory = dbFactory;
        }

        public IDbContext ConnectDb()
        {
            return (IDbContext)_factory.CreateDbContext();
        }

        public T GetService<T>() 
        {
            return _provider.GetService<T>();
        }

        public void NotifyStateChanged(params object[] evt)
        {
            StateChanged?.Invoke(evt);
        }
    }
}
