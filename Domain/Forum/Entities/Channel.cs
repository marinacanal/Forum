using Domain.Forum.ValueObjects;

namespace Domain.Forum.Entities
{
    public class Channel
    {
        public Guid ChannelId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ChannelName Name { get; private set; }
        public ChannelDescription Description { get; private set; }       

        // relacoes
        public Guid CreatorId { get; private set; }
        public User Creator { get; private set; }
        public ICollection<ChannelMembers> Members { get; private set; }
        public ICollection<Post> Posts { get; private set; }

        // constructor
        public Channel(Guid creatorId, ChannelName name) 
        {
            ChannelId = Guid.NewGuid();
            CreatorId = creatorId;
            CreatedAt = DateTime.UtcNow;
            Name = name;

            Members = new List<ChannelMembers>();
            Posts = new List<Post>();
        } 

        // updates
        public void UpdateName(ChannelName name) => Name = name;
        public void UpdateDescription(ChannelDescription description) => Description = description;
    }
}