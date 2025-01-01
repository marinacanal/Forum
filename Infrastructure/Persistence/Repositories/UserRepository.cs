using Domain.UserManagement.Entities;
using Domain.UserManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    // aqui eu herdo todos os metodos estabelecidos na minha classe Repository
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context; // readonly signifca que eu so posso atribuir o valor da variavel uma vez
        private readonly DbSet<User> _dbSet;
        public UserRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }
        
        // get by
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email) {
            return await _dbSet.FirstOrDefaultAsync(user => user.Email.Value == email);
        }

        public async Task<User> GetByUserNameAsync(string username) {
            return await _dbSet.FirstOrDefaultAsync(user => user.UserName.Value == username);
        }

        // get contains
        public async Task<List<User>> GetContainsUserNameAsync(string username) {
            return await _dbSet
                .Where(user => user.UserName.Value.Contains(username))
                .ToListAsync();
        }

        // get all
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // create
        public async Task CreateAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // update
        public async Task UpdateAsync(User user)
        {
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
        }

        // delete
        public async Task DeleteAsync(User user)
        {
            _dbSet.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}