using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Context
{
    public interface IMainContext
    {
        T GetService<T>();
        void NotifyStateChanged(params object[] evt);
        Task<T> GetCookie<T>(string key);
        Task SetCookie(string key,object value, int days = 3);
        Task RemoveCookie(string key);
        Task<bool> ExistCookie(string key);
    }
}
