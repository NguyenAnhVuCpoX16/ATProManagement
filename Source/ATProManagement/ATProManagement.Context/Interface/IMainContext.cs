using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Context
{
    public interface IMainContext
    {
        T GetService<T>();
        void NotifyStateChanged(params object[] evt);
    }
}
