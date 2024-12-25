using Domain.UserManagement.Entities;

namespace Domain.UserManagement.Interfaces
{
    public interface IUserRepository 
    {
        // get by 
        Task<User> GetByIdAsync(Guid id); // tarefa assincrona, nao bloqueia threads
        Task<User> GetByEmailAsync(string useremail);
        Task<User> GetByUserNameAsync(string username);

        // get contains
        Task <List<User>> GetContainsUserNameAsync(string username);

        // get all
        Task<IEnumerable<User>> GetAllAsync();

        // add
        Task CreateAsync(User user);

        //update
        Task UpdateAsync(User user); 

        // delete
        Task DeleteAsync(User user);
    }
}