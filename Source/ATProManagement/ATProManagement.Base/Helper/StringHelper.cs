using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Base
{
    public static class StringHelper
    {
        public static string GetAfterLast(this string str, string key)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            int idx = str.LastIndexOf(key);

            if (idx > -1)
                return str.Substring(idx + key.Length);
            else
                return str;
        }

        public static string GetBeforeLast(this string str, string key)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            int idx = str.LastIndexOf(key);

            if (idx > -1)
                return str.Substring(0, idx);
            else
                return str;
        }
    }
}
