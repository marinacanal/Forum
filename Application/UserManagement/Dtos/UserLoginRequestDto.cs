using System.ComponentModel.DataAnnotations;

namespace Application.UserManagement.Dtos
{
    public class UserLoginRequestDto
    {
        [Required]   
        public string UsernameOrEmail { get; set; }

        [Required]
        public string PlainPassword { get; set; }
    }
}