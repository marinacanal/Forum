using Domain.Forum.Entities;

namespace Domain.Forum.Interfaces
{
    public interface ICommentRepository 
    {   
        // get all by
        Task <List<Comment>> GetAllByPostIdAsync(Guid postId);

        Task <List<Comment>> GetAllByUserIdAsync(Guid userId);

        // create
        Task CreateAsync(Comment comment);

        // update
        Task UpdateAsync(Comment comment);

        // delete
        Task DeleteAsync(Comment comment);
    }
}