using Domain.Forum.Entities;
using Domain.Forum.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Forum
{
    public class ChannelMembersRepository : IChannelMembersRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<ChannelMembers> _dbSet;
        public ChannelMembersRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ChannelMembers>(); 
        }

        // get all by
        public async Task<List<Guid>> GetAllMembersByChannelIdAsync(Guid channelId)
        {
            return await _dbSet
                .Where(channelMembers => channelMembers.ChannelId == channelId)
                .Select(channelMembers => channelMembers.UserId)
                .ToListAsync();
        }

        public async Task<List<Guid>> GetAllChannelsByMemberIdAsync(Guid userId)
        {
            return await _dbSet
                .Where(channelMembers => channelMembers.UserId == userId)
                .Select(channelMembers => channelMembers.ChannelId)
                .ToListAsync();
        }
    }
}