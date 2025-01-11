using Application.Common.DTOs.UserManagement;
using Domain.UserManagement.Entities;
using Domain.UserManagement.ValueObjects;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;

namespace Application.Services.UserManagement
{
    public class UserAuthenticationService
    {
        private readonly UserRepository _userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly PasswordHasher _passwordHasher;

        public UserAuthenticationService(UserRepository userRepository, PasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserLoginResponseDto> LoginAsync(UserLoginRequestDto dto) 
        {
            var existingUser = await _userRepository.GetByUserNameAsync(dto.UsernameOrEmail); // usa await porque deve esperar retorno do repositorio, que é async
            
            if (existingUser == null || !existingUser.Password.VerifyPassword(dto.PlainPassword, _passwordHasher))
               return new UserLoginResponseDto
                {
                    IsSuccessful = false,
                    ErrorMessage = "Usuário ou senha inválido!"
                };
            
            var token = _jwtTokenGenerator.GenerateToken(existingUser.UserId);

            return new UserLoginResponseDto
                {
                    IsSuccessful = true,
                    Token = token
                };
        }

        public async Task<UserRegisterResponseDto> RegisterAsync(UserRegisterRequestDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
                return new UserRegisterResponseDto {
                    IsSuccessful = false,
                    ErrorMessage = "Conta já existente!"
                };

            var username = GenerateUsernameFromEmail(dto.Email);

            var newUser = new User(
                new Username(username),
                new Email(dto.Email),
                new Password(dto.PlainPassword, _passwordHasher)
            );
            
            await _userRepository.CreateAsync(newUser);

            return new UserRegisterResponseDto {
                IsSuccessful = true,
                UserId = newUser.UserId.ToString()
            };
        }

        private string GenerateUsernameFromEmail(string email) 
        {
            var prefix = email.Split('@')[0];
            var sanitizedPrefix = string.Concat(prefix.Where(char.IsLetterOrDigit));
            var randomSuffix = new Random().Next(1000, 9999);

            return $"{sanitizedPrefix}{randomSuffix}";
        }
    }
}