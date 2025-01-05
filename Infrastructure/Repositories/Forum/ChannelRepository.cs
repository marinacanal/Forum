using Domain.Forum.Entities;
using Domain.Forum.Interfaces;
using Domain.Forum.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Forum
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Channel> _dbSet;
        public ChannelRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Channel>(); 
        }

        // get by
        public async Task<Channel> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // get contains
        public async Task<List<Channel>> GetContainsDescriptioneAsync(ChannelDescription description)
        {
            return await _dbSet
                .Where(channel => channel.Description.Value.Contains(description.ToString()))
                .ToListAsync();
        }
        public async Task<List<Channel>> GetContainsNameAsync(ChannelName name)
        {
            return await _dbSet
                .Where(channel => channel.Name.Value.Contains(name.ToString()))
                .ToListAsync();
        }

        // get all by
        public async Task<List<Channel>> GetAllByCreatorIdAsync(Guid creatorId)
        {
            return await _dbSet
                .Where(channel => channel.CreatorId == creatorId)
                .ToListAsync();
        }

        // create
        public async Task CreateAsync(Channel channel)
        {
            await _dbSet.AddAsync(channel);
            await _context.SaveChangesAsync();
        }

        // update
        public async Task UpdateAsync(Channel channel)
        {
            _dbSet.Update(channel);
            await _context.SaveChangesAsync();
        }

        // deletes
        public async Task DeleteAsync(Channel channel)
        {
            _dbSet.Remove(channel);
            await _context.SaveChangesAsync();
        }
    }
}