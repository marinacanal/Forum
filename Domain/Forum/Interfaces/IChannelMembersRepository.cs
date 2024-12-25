namespace Domain.Forum.Interfaces
{
    public interface IChannelMembersRepository
    {
        // get all by
        Task <List<Guid>> GetAllMembersByChannelIdAsync(Guid channelId);
        Task <List<Guid>> GetAllChannelsByMemberIdAsync(Guid userId);
    }
}