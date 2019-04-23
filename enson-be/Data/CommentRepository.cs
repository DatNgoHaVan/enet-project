using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enson_be.Data
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            Create(comment);
            await SaveAsync();
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            Delete(comment);
            await SaveAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            // var comments = await FindAllAsync();
            // return comments.OrderBy(x => x.CommentId);
            return await _context.Comments
                .Include(p => p.Post)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Comment> GetCommentById(long commentId)
        {
            var comments = await FindByConditionAsync(x => x.CommentId.Equals(commentId));
            return comments.DefaultIfEmpty(new Comment()).FirstOrDefault();
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostId(long postId)
        {
            var comments = await FindByConditionAsync(x => x.PostId.Equals(postId));
            return comments.DefaultIfEmpty(new Comment()).OrderBy(x => x.CommentId);
        }

        public async Task<IEnumerable<Comment>> GetCommentByUserId(long userId)
        {
            var comments = await FindByConditionAsync(x => x.UserId.Equals(userId));
            return comments.DefaultIfEmpty(new Comment()).OrderBy(x => x.CommentId);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            Update(comment);
            await SaveAsync();
        }
    }
}