using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Context
{
    public interface IMyContext
    {
        IDbContext ConnectDb();
    }
}
