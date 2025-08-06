using Domain.Forum.ValueObjects;
using Domain.UserManagement.Entities;

namespace Domain.Forum.Entities
{
    public class Channel
    {
        public Guid ChannelId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public ChannelName Name { get; private set; }
        public ChannelDescription Description { get; private set; }  
        public string ProfilePicture { get; private set; }     

        // relationships
        public Guid CreatorId { get; private set; }
        public User Creator { get; private set; }
        public ICollection<ChannelMembers> Members { get; private set; }
        public ICollection<Post> Posts { get; private set; }

        // constructor
        public Channel(Guid creatorId, ChannelName name, ChannelDescription description) 
        {
            if (creatorId == Guid.Empty) 
                throw new ArgumentNullException("Usuário não pode ser vazio!", nameof(creatorId));
 
            ChannelId = Guid.NewGuid();
            CreatorId = creatorId;
            CreatedAt = DateTime.UtcNow;
            Name = name;
            Description = description;

            Members = new List<ChannelMembers>();
            Posts = new List<Post>();
        }

        // updates
        public void UpdateName(ChannelName name) => Name = name;
        public void UpdateDescription(ChannelDescription description) => Description = description;
        public void UpdateProfilePicture(string profilePicture)
        {
            if (profilePicture == string.Empty) 
                throw new ArgumentNullException("Foto não pode ser vazia!", nameof(profilePicture));

            ProfilePicture = profilePicture;
        }
    }
}