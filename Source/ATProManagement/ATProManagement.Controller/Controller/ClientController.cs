
using ATPromanagement.Abstract;
using ATProManagement.Context;
using ATProManagement.Core;
using ATProManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATPromanagement.Controller
{

    [ApiAuthorize]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ClientController : ClientService, IClientService
    {
        public ClientController(IMyContext ctx) : base(ctx)
        {
        }
    }
}
