using System.Security.Cryptography;
using System.Text;
using ToolPedia.Application.Common.Interfaces;

namespace ToolPedia.Application.Auth.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        const int keySize = 64;
        const int iterations = 350000;
        readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public string HashPassword(string password, out string salt)
        {
            var saltB = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                saltB,
                iterations,
                hashAlgorithm,
                keySize
            );

            salt = Convert.ToHexString(saltB);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hashedPassword, string salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                password,
                Convert.FromHexString(salt),
                iterations,
                hashAlgorithm,
                keySize
            );

            return CryptographicOperations.FixedTimeEquals(
                hashToCompare,
                Convert.FromHexString(hashedPassword)
            );
        }
    }
}
