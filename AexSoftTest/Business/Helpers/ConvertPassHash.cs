using System;
using System.Security.Cryptography;
using System.Text;

namespace Business.Helpers
{
    internal class ConvertPassHash
    {
        public static string ConvertHash(string pass)
        {
            MD5 csd = MD5.Create();
            string result = Convert.ToBase64String(csd.ComputeHash(Encoding.Unicode.GetBytes(pass)));
            return result;
        }
    }
}
