using Forum.Models;

namespace Forum.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<Comment> GetCommentByIdAsync(int id);
        Task CreateCommentaryAsync(Comment comment);
        Task UpdateCommentaryAsync(Comment comment);
        Task DeleteCommentaryAsync(int id);
    }
}