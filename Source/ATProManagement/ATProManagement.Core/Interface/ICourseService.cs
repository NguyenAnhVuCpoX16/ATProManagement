using ATProManagement.Base;
using ATProManagement.Db;
using ATProManagement.Service;
using Microsoft.AspNetCore.Mvc;
using RestEase;
namespace ATProManagement.Core
{
    public interface ICourseService : IServiceBase
    {
        [Post(nameof(GetData))]
        Task<PagedResultsOf<EntityCourse>> GetData([FromBody] FilterDto filter = null);

        [Post(nameof(Submit))]
        Task<ResultOf<ModelCourse>> Submit([Body] ModelCourse model);

        [Post(nameof(Delete))]
        Task<Result> Delete(Guid guid);

        [Post(nameof(RemoveRange))]
        Task<Result> RemoveRange(List<EntityCourse> list);
    }
}
