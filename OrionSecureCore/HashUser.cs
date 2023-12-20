using System;
using System.Security.Cryptography;
using System.Text;

namespace OrionSecureCore
{
    public class HashUser
    {
        private string _hashedSalt, _hashedPassword;

        public string CreateSalt()
        {
            string currentDate = GetCurrentDate("yyyyMMdd");
            return _hashedSalt = HashString(currentDate);
        }

        public string CreatePassword(string password, string salt)
        {
            _hashedPassword = HashString(password + salt);
            return _hashedPassword;
        }

        public string ValidatePassword(string password, string salt)
        {
            return HashString(password + salt);
        }

        private string GetCurrentDate(string dateFormat)
        {
            return DateTime.Now.ToString(dateFormat);
        }

        private static string HashString(string stringToHash)
        {
            using (SHA256 hash = SHA256.Create())
            {
                byte[] hashedBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                return BitConverter.ToString(hashedBytes);
            }
        }
    }
}
