using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs.UserManagement
{
    public class UserRegisterRequestDto
    {
        [Required]   
        public string Email { get; set; }

        [Required]
        public string PlainPassword { get; set; }
    }
}