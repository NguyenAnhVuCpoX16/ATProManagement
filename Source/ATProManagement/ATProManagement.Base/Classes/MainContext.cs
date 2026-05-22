using Microsoft.Extensions.DependencyInjection;

namespace ATProManagement.Context
{
    public class MainContext : IMainContext
    {
        public event Action<object[]> StateChanged;
        private readonly IServiceProvider _provider;
        private readonly IMyCookie _cookie;
        public MainContext(IServiceProvider provider, IMyCookie cookie)
        {
            _provider = provider;
            _cookie = cookie;
        }
        public T GetService<T>()
        {
            return _provider.GetService<T>();
        }

        public void NotifyStateChanged(params object[] evt)
        {
            StateChanged?.Invoke(evt);
        }

        public async Task<T> GetCookie<T>(string key)
        {
            return await _cookie.Get<T>(key);
        }

        public Task SetCookie(string key, object value, int days = 3)
        {
            return _cookie.Set(key, value, days);
        }

        public Task RemoveCookie(string key)
        {
            return _cookie.Remove(key);
        }

        public async Task<bool> ExistCookie(string key)
        {
            return await _cookie.Exist(key);
        }
    }
}
