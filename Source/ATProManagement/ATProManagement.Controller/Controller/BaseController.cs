using ATProManagement.Base;
using ATProManagement.Context;
using Microsoft.AspNetCore.Mvc;

namespace ATProManagement.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : MyServiceBase, IServiceBase
    {
        public BaseController(IMyContext _ctx, ILogger<BaseController> log) : base(_ctx, log)
        {
        }
    }
}
