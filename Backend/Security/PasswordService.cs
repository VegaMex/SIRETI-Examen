using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Backend.Security
{
    public class PasswordService
    {
        public static string GetHash(string password)
        {
            var sha = new SHA1CryptoServiceProvider();
            var byteArray = Encoding.ASCII.GetBytes(password);
            var hashed = sha.ComputeHash(byteArray);
            return BitConverter.ToString(hashed).Replace("-", "").ToLower();
        }
    }
}
