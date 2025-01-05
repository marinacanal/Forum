using Domain.Forum.Entities;
using Domain.Forum.Enums;
using Domain.Forum.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Forum
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Reaction> _dbSet;
        public ReactionRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Reaction>();
        }

        // get by
        public async Task<Reaction> GetByTargetTypeAndUserAsync(Guid userId, Guid targetId, TargetType targetType)
        {
            return await _dbSet
                .Where(reaction => reaction.UserId == userId 
                    && reaction.TargetId == targetId 
                    && reaction.TargetType == targetType)
                .FirstAsync();
        }
        
        // get all
        public async Task<List<Reaction>> GetAllByTargetTypeAsync(Guid targetId, TargetType targetType)
        {
            return await _dbSet
                .Where(reaction => reaction.TargetId == targetId 
                    && reaction.TargetType == targetType)
                .ToListAsync();
        }

        public async Task<List<Reaction>> GetAllByUserAsync(Guid userId)
        {
            return await _dbSet
                .Where(reaction => reaction.UserId == userId)
                .ToListAsync();
        }
        
        // create
        public async Task CreateAsync(Reaction reaction)
        {
            await _dbSet.AddAsync(reaction);
            await _context.SaveChangesAsync();
        }

        // delete
        public async Task DeleteAsync(Reaction reaction)
        {
            _dbSet.Remove(reaction);
            await _context.SaveChangesAsync();
        }
    }
}