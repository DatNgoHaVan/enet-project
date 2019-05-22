using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enet_be.Data;
using enet_be.Domain.Services;
using enet_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enet_be.Services
{
    public class CommentService : ICommentService
    {
        private IRepositoryBase<Comment> _commentRepository;
        public CommentService(IRepositoryBase<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            _commentRepository.Create(comment);
            await _commentRepository.SaveAsync();
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            _commentRepository.Delete(comment);
            await _commentRepository.SaveAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            var commentToReturn = await _commentRepository.FindAll()
                            .Include(x => x.User)
                            .OrderBy(x => x.CommentId)
                            .ToListAsync();
            return commentToReturn;
        }

        public async Task<Comment> GetCommentById(long commentId)
        {
            var commentToReturn = await _commentRepository
                            .FindByCondition(x => x.CommentId.Equals(commentId))
                            .Include(x => x.User)
                            .ToListAsync();
            return commentToReturn.FirstOrDefault();
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostId(long postId)
        {
            var commentToReturn = await _commentRepository
                            .FindByCondition(x => x.PostId.Equals(postId))
                            .Include(x => x.User)
                            .OrderBy(x => x.CommentId)
                            .ToListAsync();
            return commentToReturn;
        }

        public async Task<IEnumerable<Comment>> GetCommentByUserId(long userId)
        {
            var commentToReturn = await _commentRepository
                            .FindByCondition(x => x.PostId.Equals(userId))
                            .Include(x => x.User)
                            .OrderBy(x => x.CommentId)
                            .ToListAsync();
            return commentToReturn;
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _commentRepository.Update(comment);
            await _commentRepository.SaveAsync();
        }
    }
}