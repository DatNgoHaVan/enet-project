using System.Collections.Generic;
using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public Task CreateCommentAsync(Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCommentAsync(Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAllComment()
        {
            throw new System.NotImplementedException();
        }

        public Task<Comment> GetCommentById(long commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetCommentByPostId(long postId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetCommentByUserId(long userId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCommentAsync(Comment comment)
        {
            throw new System.NotImplementedException();
        }
    }
}