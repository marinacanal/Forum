namespace Application.Common.DTOs.UserManagement
{
    public class UserRegisterResponseDto
    {
        public bool IsSuccessful { get; set; }
        public string UserId { get; set; }
        public string ErrorMessage { get; set; }
    }
}