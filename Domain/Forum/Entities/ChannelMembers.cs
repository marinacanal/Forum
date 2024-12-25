using Domain.UserManagement.Entities;

namespace Domain.Forum.Entities
{
    public class ChannelMembers
    {   
        public Guid ChannelMembersId { get; private set; }

        // relationships
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid ChannelId { get; private set; }
        public Channel Channel { get; private set; }        

        // constructor
        public ChannelMembers(Guid userId, Guid channelId)
        {   
            ChannelMembersId = Guid.NewGuid();
            UserId = userId;
            ChannelId = channelId;
        }
    }
}