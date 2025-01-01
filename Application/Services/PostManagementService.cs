using Domain.Forum.Entities;
using Domain.Forum.ValueObjects;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class PostManagementService
    {
        private readonly PostRepository _postRepository;

        public PostManagementService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> CreatePostAsync(Guid userId, Guid chananelId, string title, string content)
        {   
            var newPost = new Post(
                new PostTitle(title),
                new PostContent(content),
                userId,
                chananelId
            );

            await _postRepository.CreateAsync(newPost);
            return newPost;
        }   

        public async Task<bool> UpdatePostAsync(Guid userId, Guid postId, PostTitle postTitle, PostContent postContent) 
        {
            var post = await _postRepository.GetByIdAsync(postId);
            
            if (post == null)
                throw new ArgumentNullException("Post não encontrado!");

            if (post.UserId != userId)
                throw new UnauthorizedAccessException("Você não pode atualizar esse post!");

            post.UpdatePost(postTitle, postContent);
            await _postRepository.UpdateAsync(post);
            return true;
        }

        public async Task<bool> DeletePostAsync(Guid userId, Guid postId) 
        {
            var post = await _postRepository.GetByIdAsync(postId);
            
            if (post == null)
                throw new ArgumentNullException("Post não encontrado!");

            if (post.UserId != userId)
                throw new UnauthorizedAccessException("Você não pode deletar esse post!");

            await _postRepository.DeleteAsync(post);
            return true;
        }
    }
}