using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Context
{
    public class MainContext : IMainContext
    {
        public event Action<object[]> StateChanged;
        private readonly IServiceProvider _provider;
        public MainContext(IServiceProvider provider)
        {
            _provider = provider;
        }
        public T GetService<T>()
        {
            return _provider.GetService<T>();
        }

        public void NotifyStateChanged(params object[] evt)
        {
            StateChanged?.Invoke(evt);
        }
    }
}
