using Domain.Forum.Entities;
using Domain.Forum.ValueObjects;

namespace Domain.Forum.Interfaces 
{
    public interface IPostRepository {

        // get by
        Task<Post> GetByIdAsync(Guid id);
        Task<List<Post>> GetByUserIdAsync(Guid userId);

        // get contains
        Task<List<Post>> GetContainsContentAsync(PostContent content);
        Task<List<Post>> GetContainsTitleAsync(PostTitle title);

        // get in
        Task<List<Post>> GetInChannelAsync(Guid channelId);

        // get all
        Task<List<Post>> GetAllAsync();

        // create
        Task CreateAsync(Post post);

        // update
        Task UpdateAsync(Post post);

        // delete
        Task DeleteAsync(Post post);
    }
}