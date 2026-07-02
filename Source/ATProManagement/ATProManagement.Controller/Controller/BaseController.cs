using ATPromanagement.Abstract;
using ATProManagement.Base;
using ATProManagement.Context;
using Microsoft.AspNetCore.Mvc;

namespace ATProManagement.Controller
{
    [ApiAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class BaseController : MyServiceBase, IServiceBase
    {
        public BaseController(IMyContext _ctx) : base(_ctx)
        {
        }
    }
}
