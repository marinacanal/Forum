using Domain.UserManagement.Entities;
using Domain.UserManagement.ValueObjects;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Security;

namespace Application.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;

        public AuthenticationService(UserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> LoginAsync(string username, string plainTextPassword) 
        {
            var user = await _userRepository.GetByUserNameAsync(username); // usa await porque deve esperar retorno do repositorio, que é async
            
            if (user == null || !user.Password.VerifyPassword(plainTextPassword, _passwordHasher))
               throw new ArgumentException("Usuário ou senha inválido!");

            return true;
        }

        public async Task<User> RegisterAsync(string username, string useremail, string plainTextPassword)
        {
            var user = await _userRepository.GetByUserNameAsync(username);

            if (user != null)
                throw new ArgumentException("Username já utilizado!");

            var newUser = new User(
                new Username(username),
                new Email(useremail),
                new Password(plainTextPassword, _passwordHasher)
            );
            
            await _userRepository.CreateAsync(newUser);
            return newUser;
        }
    }
}