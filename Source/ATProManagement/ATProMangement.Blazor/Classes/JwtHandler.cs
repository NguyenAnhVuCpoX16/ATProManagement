using ATProManagement.Base;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

public class JwtHandler : DelegatingHandler
{
    private readonly ILocalStorageService _storage;
    private readonly NavigationManager _nav;

    public JwtHandler(
        ILocalStorageService storage,
        NavigationManager nav)
    {
        _storage = storage;
        _nav = nav;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var auth = await _storage.GetItemAsync<AuthToken>("auth");

        if (auth != null)
        {
            if (auth.ExpireAt <= DateTime.UtcNow)
            {
                await _storage.RemoveItemAsync("auth");

                _nav.NavigateTo("/login", true);

                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", auth.Token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}