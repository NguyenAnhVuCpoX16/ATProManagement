
using ATProManagement.Base;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ATProMangement.Blazor
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storage;

        public CustomAuthStateProvider(ILocalStorageService storage)
        {
            _storage = storage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _storage.GetItemAsync<AuthToken>("auth");

            if (token == null)
            {
                return Anonymous();
            }

            if (token.ExpireAt <= DateTime.UtcNow)
            {
                await _storage.RemoveItemAsync("auth");
                return Anonymous();
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "User")
            }, "jwt");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private AuthenticationState Anonymous()
        {
            return new AuthenticationState(
                new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
