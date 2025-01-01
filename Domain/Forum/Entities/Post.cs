using Domain.Forum.ValueObjects;
using Domain.UserManagement.Entities;

namespace Domain.Forum.Entities
{
    public class Post
    {
        public Guid PostId { get; private set; }
        public PostTitle Title { get; private set; }
        public PostContent Content { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // relationships
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid ChannelId { get; private set; }
        public Channel Channel { get; private set; }       
        public ICollection<Reaction> Reactions { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        // constructor
        public Post(PostTitle title, PostContent content, Guid userId, Guid channelId) 
        {   
            PostId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UserId = userId;
            ChannelId = channelId;
            Title = title; 
            Content = content;

            Comments = new List<Comment>();
            Reactions = new List<Reaction>();
        }

        public void UpdatePost(PostTitle title, PostContent content) 
        {
            Title = title;
            Content = content;
        }

        public void AddComment(Comment comment) 
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));

            Comments.Add(comment);
        }

        public void AddLike(Reaction reaction) 
        {
            if (reaction == null) throw new ArgumentNullException(nameof(reaction));
            
            Reactions.Add(reaction);
        }
    }
}