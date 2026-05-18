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
        Task<PagedResultsOf<EntityClient>> GetData([FromBody] FilterDto filter);

        [Post(nameof(Submit))]
        Task<ResultOf<ModelClient>> Submit([Body] ModelClient model);

        [Post(nameof(Delete))]
        Task<Result> Delete(Guid guid);
    }
}
