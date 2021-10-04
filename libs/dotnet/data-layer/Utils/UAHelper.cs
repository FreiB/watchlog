using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchLog.Infra.Data.Utils
{
    public class UAHelper
    {
        public static string BuildVersionString(string major, string minor, string patch)
        {
            string result = string.Empty;
            StringBuilder stringBuilder = new StringBuilder(result);
            if (!string.IsNullOrEmpty(major))
            {
                stringBuilder.Append(major);
            }

            if (!string.IsNullOrEmpty(minor))
            {
                stringBuilder.Append(".");
                stringBuilder.Append(minor);
            }

            if (!string.IsNullOrEmpty(patch))
            {
                stringBuilder.Append(".");
                stringBuilder.Append(patch);
            }

            result = stringBuilder.ToString();
            return result;
        }
    }
}
