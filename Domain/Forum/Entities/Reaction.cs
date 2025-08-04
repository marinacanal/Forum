using Domain.Forum.Enums;
using Domain.UserManagement.Entities;

namespace Domain.Forum.Entities
{   
    public class Reaction
    {
        public Guid ReactionId { get; private set; }
        public Guid? TargetId { get; private set; }
        public TargetType TargetType { get; private set; }
        public ReactionType Type { get; private set; } 

        // relationships
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        // constructor
        public Reaction(Guid userId, Guid targetId, TargetType targetType, ReactionType reactionType)
        {
            if (userId == Guid.Empty) 
                throw new ArgumentNullException("Usuário não pode ser vazio!", nameof(userId));

            if (targetType == TargetType.Post && targetId == Guid.Empty)
                throw new ArgumentException("Post não pode ser vazio!", nameof(targetId));

            if (targetType == TargetType.Comment && targetId == Guid.Empty)
                throw new ArgumentException("Comentário não pode ser vazio!", nameof(targetId));

            ReactionId = Guid.NewGuid();
            UserId = userId;
            TargetId = targetId;
            TargetType = targetType;
            Type = reactionType;
        }

        // verifica se o usuário curtiu ou descurtiu
        public bool IsLiked() => Type == ReactionType.Like;
        public bool IsDisliked() => Type == ReactionType.Dislike;
    }
}