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
            if (userId == Guid.Empty) 
                throw new ArgumentNullException("Usuário não pode ser vazio!", nameof(userId));
                
            if (channelId == Guid.Empty) 
                throw new ArgumentNullException("Canal não pode ser vazio!", nameof(channelId));

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
            if (comment == null) throw new ArgumentNullException("Comentário não pode ser vazio!", nameof(comment));

            Comments.Add(comment);
        }

        public void AddReaction(Reaction reaction) 
        {
            if (reaction == null) throw new ArgumentNullException("Reação não pode ser vazia!", nameof(reaction));
            
            Reactions.Add(reaction);
        }
    }
}