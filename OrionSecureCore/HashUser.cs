using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace OrionSecureCore
{
    class HashUser
    {
        private const string PASSWORD = "12345aA";
        public string createSalt()
        {
            string salt = DateTime.Now.ToString("yyyyMMdd");

            salt = hashString(salt);

            return salt;
        }

        public string createPassword(string salt)
        {
            string password = hashString(salt + PASSWORD);

            return password;
        }

        public string validatePassword(string password)
        {
            string salt = hashString(DateTime.Now.ToString("yyyyMMdd"));

            password = hashString(salt + password);

            return password;
        }

        private static string hashString(string stringToHash)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] hashedBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                return BitConverter.ToString(hashedBytes);
            }
        }
    }
}
