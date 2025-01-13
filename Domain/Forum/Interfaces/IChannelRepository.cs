using Domain.Forum.Entities;
using Domain.Forum.ValueObjects;

namespace Domain.Forum.Interfaces
{
    public interface IChannelRepository
    {
        // get by
        Task <Channel> GetByIdAsync(Guid id);
        Task <Channel> GetByNameAsync(string name);

        // get all
        Task <List<Channel>> GetAllAsync();

        // get all by
        Task <List<Channel>> GetAllByCreatorIdAsync(Guid creatorId);

        // get contains
        Task <List<Channel>> GetContainsNameAsync(string name);
        Task <List<Channel>> GetContainsDescriptionAsync(string description);

        // create
        Task CreateAsync(Channel channel);

        // update
        Task UpdateAsync(Channel channel);

        // delete
        Task DeleteAsync(Channel channel);
    }
}