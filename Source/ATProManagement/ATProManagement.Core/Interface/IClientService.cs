using ATPromanagement.Base;
using ATProManagement.Base;
using ATProManagement.Db;
using ATProManagement.Service;
using Microsoft.AspNetCore.Mvc;
using RestEase;


namespace ATProManagement.Core
{
    public interface IClientService : IServiceBase
    {
        [Post(nameof(GetData))]
        Task<PagedResultsOf<EntityClient>> GetData([FromBody] FilterDto filter = null);

        [Post(nameof(Submit))]
        Task<ResultOf<ModelClient>> Submit([Body] ModelClient model);

        [Post(nameof(Delete))]
        Task<Result> Delete(Guid guid);

        [Post(nameof(RemoveRange))]
        Task<Result> RemoveRange(List<EntityClient> list);

        [Post(nameof(GetCourseOptions))]
        Task<ResultsOf<OptionItem<string>>> GetCourseOptions();
    }
}
