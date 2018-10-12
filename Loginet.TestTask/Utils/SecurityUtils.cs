using System;
using System.Text;
using System.Security.Cryptography;

namespace Loginet.TestTask.Utils
{
    public static class SecurityUtils
    {
        public static string GetHashFromString(string value)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", string.Empty);
            }
        }
    }
}
