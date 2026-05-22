using ATProManagement.Db;
namespace ATProManagement.Context
{
    public interface IMyContext
    {
        IDbContext ConnectDb();
    }
}
