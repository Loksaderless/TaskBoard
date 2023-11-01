using System.Security.Cryptography;
using System.Text;

namespace TaskBoard.Service.Helpers
{
    public class HashHelpers
    {
        public static string HashPasswordCode(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
