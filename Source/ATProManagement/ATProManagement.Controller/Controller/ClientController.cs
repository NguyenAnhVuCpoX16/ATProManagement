
using ATProManagement.Context;
using ATProManagement.Core;
using ATProManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace ATPromanagement.Controller
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientController : ClientService, IClientService
    {
        public ClientController(IMyContext ctx) : base(ctx)
        {
        }
    }
}
