using ATProManagement.Base;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ATProMangement.Blazor.Controller
{
    [ApiController]
    [Route("api/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly ILocalStorageService _storage;
        private readonly NavigationManager _nav;

        public AuthController(IAuthService auth, ILocalStorageService storage, NavigationManager nav)
        {
            _auth = auth;
            _storage = storage;
            _nav = nav;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _auth.Login(dto.Email, dto.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var result = await _auth.CreateUser(dto);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => new
                {
                    x.Code,
                    x.Description
                }));
            }

            return Ok();
        }

        [HttpPost("logout")]
        public async Task Logout()
        {
            await _storage.RemoveItemAsync("token");
            _nav.NavigateTo("/login", true);
        }
    }
}
