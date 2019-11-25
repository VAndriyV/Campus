using System;
using System.Security.Cryptography;
using System.Text;

namespace Campus.Infrastructure.Helpers
{
    public sealed class PasswordHasher
    {
        public byte Version => 1;
        public int SaltSize { get; } = 128 / 8; // 128 bits
        public HashAlgorithmName HashAlgorithmName { get; } = HashAlgorithmName.SHA256;

        public string HashPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            byte[] salt = GenerateSalt(SaltSize);
            byte[] hash = HashPasswordWithSalt(password, salt);

            var inArray = new byte[1 + SaltSize + hash.Length];
            inArray[0] = Version;
            Buffer.BlockCopy(salt, 0, inArray, 1, SaltSize);
            Buffer.BlockCopy(hash, 0, inArray, 1 + SaltSize, hash.Length);

            return Convert.ToBase64String(inArray);
        }

        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            if (hashedPassword == null)
                return false;

            Span<byte> numArray = Convert.FromBase64String(hashedPassword);
            if (numArray.Length < 1)
                return false;

            byte version = numArray[0];
            if (version > Version)
                return false;

            var salt = numArray.Slice(1, SaltSize).ToArray();
            var bytes = numArray.Slice(1 + SaltSize).ToArray();

            var hash = HashPasswordWithSalt(password, salt);

            if (CryptographicOperations.FixedTimeEquals(hash, bytes))
                return true;

            return false;
        }

        private byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            byte[] hash;
            using (var hashAlgorithm = HashAlgorithm.Create(HashAlgorithmName.Name))
            {
                byte[] input = Encoding.UTF8.GetBytes(password);
                hashAlgorithm.TransformBlock(salt, 0, salt.Length, salt, 0);
                hashAlgorithm.TransformFinalBlock(input, 0, input.Length);
                hash = hashAlgorithm.Hash;
            }

            return hash;
        }

        private static byte[] GenerateSalt(int byteLength)
        {
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var data = new byte[byteLength];
                cryptoServiceProvider.GetBytes(data);
                return data;
            }
        }       
    }   
}
