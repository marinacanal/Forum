using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs.UserManagement
{
    public class UserLoginRequestDto
    {
        [Required]   
        public string UsernameOrEmail { get; set; }

        [Required]
        public string PlainPassword { get; set; }
    }
}