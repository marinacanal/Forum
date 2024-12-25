using Domain.Forum.Entities;
using Domain.Forum.ValueObjects;

namespace Domain.Forum.Interfaces
{
    public interface IChannelRepository
    {
        // get by
        Task <Channel> GetByIdAsync(Guid id);

        // get all by
        Task <List<Channel>> GetAllByCreatorIdAsync(Guid creatorId);

        // get contains
        Task <List<Channel>> GetContainsNameAsync(ChannelName name);
        Task <List<Channel>> GetContainsDescriptioneAsync(ChannelDescription description);

        // create
        Task CreateAsync(Channel channel);

        // update
        Task UpdateAsync(Channel channel);

        // delete
        Task DeleteAsync(Channel channel);
    }
}