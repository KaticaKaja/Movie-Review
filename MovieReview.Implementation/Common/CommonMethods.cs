using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Implementation.Common
{
    public static class CommonMethods
    {
        public static string key = "assdg@#%$df";

        public static string ConvertToEncrypt(string password)
        {
            password += key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            var based64EncodeData = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(based64EncodeData);
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }
    }
}
