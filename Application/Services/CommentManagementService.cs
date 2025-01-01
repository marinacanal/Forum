using Domain.Forum.Entities;
using Domain.Forum.ValueObjects;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CommentManagementService
    {
        private readonly CommentRepository _commentRepository;

        public CommentManagementService(CommentRepository commentRepository) 
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> CreateCommentAsync(Guid userId, Guid postId, string commentContent)
        {
            var newComment = new Comment(
                userId,
                postId,
                new CommentContent(commentContent)
            );

            await _commentRepository.CreateAsync(newComment);
            return newComment;
        }   

        public async Task<bool> UpdateCommentAsync(Guid userId, Guid commentId, CommentContent commentContent) 
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            
            if (comment == null)
                throw new ArgumentNullException("Comentário não encontrado!");
            
            if (comment.Post == null)
                throw new ArgumentNullException("Post do comentário não encontrado!");
                
            if (comment.UserId != userId)
                throw new UnauthorizedAccessException("Você não pode atualizar esse comentário!");
            
            comment.UpdateContent(commentContent);
            await _commentRepository.UpdateAsync(comment);
            return true;
        }

        public async Task<bool> DeletePostAsync(Guid userId, Guid commentId) 
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);
            
            if (comment == null)
                throw new ArgumentNullException("Comentário não encontrado!");
            
            if (comment.Post == null)
                throw new ArgumentNullException("Post do comentário não encontrado!");
                
            if (comment.UserId != userId)
                throw new UnauthorizedAccessException("Você não pode deletar esse comentário!");

            await _commentRepository.DeleteAsync(comment);
            return true;
        }
    }
}