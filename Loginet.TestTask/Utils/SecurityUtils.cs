using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;

namespace Loginet.TestTask.Utils
{
    public static class SecurityUtils
    {
        public const string AuthTokenSessionKey = "AuthToken";

        public static string GetHashFromString(string value)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", string.Empty);
            }
        }

        public static bool Authenticate(ISession session, string token)
        {
            // Validate token.
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            // Save authentication flag in the session
            if (session != null)
            {
                session.SetInt32(AuthTokenSessionKey, 1);
                return true;
            }

            return false;
        }

        public static bool IsAuthenticated(ISession session)
        {
            if (session == null)
            {
                return false;
            }

            var authenticationFlag = session.GetInt32(AuthTokenSessionKey);

            return authenticationFlag.HasValue ? authenticationFlag.Value == 1 : false;
        }
    }
}
