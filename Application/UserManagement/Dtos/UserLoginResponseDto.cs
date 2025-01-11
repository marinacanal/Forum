namespace Application.UserManagement.Dtos
{
    public class UserLoginResponseDto
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
    }
}