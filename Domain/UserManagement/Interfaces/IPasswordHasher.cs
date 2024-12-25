namespace Domain.UserManagement.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string plainTextPassword);
        bool VerifyPassword(string plainTextPassword, string password);
    }
}