using System.ComponentModel.DataAnnotations;

namespace Application.UserManagement.Dtos
{
    public class UserRegisterRequestDto
    {
        [Required]   
        public string Email { get; set; }

        [Required]
        public string PlainPassword { get; set; }
    }
}