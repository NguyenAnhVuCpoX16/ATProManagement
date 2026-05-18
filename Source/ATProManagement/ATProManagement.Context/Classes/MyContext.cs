using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Context
{
    public class MyContext : IMyContext
    {
        private readonly IDbContext _db;
        public MyContext(IDbContext db)
        {
            _db = db;
        }

        public IDbContext ConnectDb()
        {
            return _db;
        }
    }
}
