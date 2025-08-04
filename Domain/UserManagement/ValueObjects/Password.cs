using System.Text.RegularExpressions;
using Domain.UserManagement.Interfaces;

namespace Domain.UserManagement.ValueObjects {

    public class Password
    {   
        public string Value { get; private set; } // retorna a senha

        // construtor, garante que a senha sempre seja valida
        public Password(string value, IPasswordHasher passwordHasher) {

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A senha não pode ser vazia!");

            if (value.Length < 8)
                throw new ArgumentException("A senha tem que ter pelo menos 8 caracteres!");

            if (!Regex.IsMatch(value, @"[A-Za-z]"))
                throw new ArgumentException("A senha tem que ter pelo menos uma letra!");

            if (!Regex.IsMatch(value, @"\d"))
                throw new ArgumentException("A senha tem que ter pelo menos um número!");

            if (!Regex.IsMatch(value, @"[\W_]"))
                throw new ArgumentException("A senha tem que ter pelo menos um caracter especial!");

            Value = passwordHasher.HashPassword(value);
        }

        public bool VerifyPassword(string plainTextPassword, IPasswordHasher passwordHasher)
        {
            return passwordHasher.VerifyPassword(plainTextPassword, Value);
        }
    }
}