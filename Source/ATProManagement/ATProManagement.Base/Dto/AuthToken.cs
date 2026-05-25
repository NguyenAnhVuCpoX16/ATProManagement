using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Base
{
    public class AuthToken
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
