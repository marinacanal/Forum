using Domain.Forum.Entities;
using Domain.Forum.Enums;

namespace Domain.Forum.Interfaces
{
    public interface IReactionRepository
    {  
        // get by
        Task <Reaction> GetByTargetTypeAndUserAsync(Guid userId, Guid targetId, TargetType targetType);

        // get all by
        Task <List<Reaction>> GetAllByTargetTypeAsync(Guid targetId, TargetType targetType); // post or comment
        Task <List<Reaction>> GetAllByUserAsync(Guid userId); 

        // create
        Task CreateAsync(Reaction reaction);

        // delete
        Task DeleteAsync(Reaction reaction);
    }
}