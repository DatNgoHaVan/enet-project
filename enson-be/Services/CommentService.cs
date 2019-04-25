using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Data;
using enson_be.Domain.Services;
using enson_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enson_be.Services
{
    public class CommentService : ICommentService
    {
        private IRepositoryBase<Comment> _repo;
        public CommentService(IRepositoryBase<Comment> repo)
        {
            _repo = repo;
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            _repo.Create(comment);
            await _repo.SaveAsync();
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            _repo.Delete(comment);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            var commentToReturn = await _repo.FindAll()
                            .Include(x => x.User)
                            .OrderBy(x => x.CommentId)
                            .ToListAsync();
            return commentToReturn;
        }

        public async Task<Comment> GetCommentById(long commentId)
        {
            var commentToReturn = await _repo
                            .FindByCondition(x => x.CommentId.Equals(commentId))
                            .Include(x => x.User)
                            .ToListAsync();
            return commentToReturn.FirstOrDefault();
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostId(long postId)
        {
            var commentToReturn = await _repo
                            .FindByCondition(x => x.PostId.Equals(postId))
                            .Include(x => x.User)
                            .OrderBy(x => x.CommentId)
                            .ToListAsync();
            return commentToReturn;

        }

        public async Task<IEnumerable<Comment>> GetCommentByUserId(long userId)
        {
            var commentToReturn = await _repo
                            .FindByCondition(x => x.PostId.Equals(userId))
                            .Include(x => x.User)
                            .OrderBy(x => x.CommentId)
                            .ToListAsync();
            return commentToReturn;
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _repo.Update(comment);
            await _repo.SaveAsync();
        }
    }
}