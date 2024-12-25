using System.Security.Cryptography;
using System.Text;
using Domain.UserManagement.Interfaces;
using Konscious.Security.Cryptography;

namespace Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; // define o tamanho do salt, 128 bits
        private const int HashSize = 32; // define o tamanho do hash, 256 bits
        private const int MemoryCost = 65536; // memoria usada no processo de hashing, 64 MB
        private const int TimeCost = 4; // iterações do algoritmo
        private const int DegreeOfParallelism = 2; // threads usadas

        public string HashPassword(string plainTextPassword)
        {   
            var saltBytes = new byte[SaltSize]; // inicializa array saltBytes
            var rng = RandomNumberGenerator.Create(); // gera numeros randomicos
            rng.GetBytes(saltBytes); // popula saltBytes com random bytes gerados
            var salt = Convert.ToBase64String(saltBytes); // converte bytes p/ string

            byte[] passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword); // password bytes

            var argon2id = new Argon2id(passwordBytes)
            {
                Salt = saltBytes,
                DegreeOfParallelism = DegreeOfParallelism,
                Iterations = TimeCost,
                MemorySize = MemoryCost
            };

            byte[] hashBytes = argon2id.GetBytes(HashSize);
            string hashedPassword = Convert.ToBase64String(hashBytes);

            var salt_hashedPassword = $"{hashedPassword}${salt}";

            return salt_hashedPassword;
        }

        public bool VerifyPassword(string plainTextPassword, string password)
        {   
            var salt_hashedPassword = HashPassword(plainTextPassword);

            var parts = salt_hashedPassword.Split('$'); // separador

            if (parts.Length != 2)
                throw new ArgumentException("Senha em formato inválido!");

            var storedHash = parts[0]; // hashed password 
            var storedSalt = parts[1]; // salt 

            var saltBytes = Convert.FromBase64String(storedSalt);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var argon2Id = new Argon2id(passwordBytes)
            {
                Salt = saltBytes,
                MemorySize = MemoryCost,
                Iterations = TimeCost,
                DegreeOfParallelism = DegreeOfParallelism
            };

            byte[] hashBytes = argon2Id.GetBytes(HashSize);
            string computedHash = Convert.ToBase64String(hashBytes);

            // compara hashes
            return CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(computedHash),
                Encoding.UTF8.GetBytes(storedHash)
            );
        }
    }
}