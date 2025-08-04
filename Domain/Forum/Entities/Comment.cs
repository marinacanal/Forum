using Domain.Forum.ValueObjects;
using Domain.UserManagement.Entities;

namespace Domain.Forum.Entities
{
    public class Comment
    {
        public Guid CommentId { get; private set; }
        public CommentContent Content { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // relationships
        public Guid PostId { get; private set; }
        public Post Post { get; private set; } 
        public Guid UserId { get; private set; }  
        public User User { get; private set; }
        public ICollection<Reaction> Reactions { get; private set; }

        // constructor
        public Comment(Guid userId, Guid postId, CommentContent content) 
        {
            if (userId == Guid.Empty) 
                throw new ArgumentNullException("Usuário não pode ser vazio!", nameof(userId));

            if (postId == Guid.Empty) 
                throw new ArgumentNullException("Post não pode ser vazio!", nameof(postId));            
            
            CommentId = Guid.NewGuid();
            UserId = userId;
            PostId = postId;
            Content = content;
            CreatedAt = DateTime.UtcNow;

            Reactions = new List<Reaction>();
        }

        public void UpdateContent(CommentContent content) => Content = content;
        
        public void AddReaction(Reaction reaction) 
        {
            if (reaction == null) 
                throw new ArgumentNullException("Reação não pode ser vazia!", nameof(reaction));
            
            Reactions.Add(reaction);
        }
    }
}