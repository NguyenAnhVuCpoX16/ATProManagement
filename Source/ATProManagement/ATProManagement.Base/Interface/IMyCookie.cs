using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Context
{
    public interface IMyCookie
    {
        Task Set(string key, object value, int days=3);
        Task<T> Get<T>(string key);
        Task Remove(string key);

        Task<bool> Exist(string key);
        Task Clear();

    }
}
