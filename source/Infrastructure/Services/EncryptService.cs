using System.Security.Cryptography;
using System.Text;
using Project.Application.Common.Interfaces;

namespace Project.Infrastructure.Services
{
    public static class Encrypt {

        public static string EncryptPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.HashData(bytes);

            return Convert.ToBase64String(hash);
        }
    }
    public class EncryptService : IEncryptService
    {
        public string EncryptPassword(string password)
        {
           return Encrypt.EncryptPassword(password);
        }
    }
}
