using System.Collections.Generic;
using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllComment();
        Task<Comment> GetCommentById(long commentId);
        Task<IEnumerable<Comment>> GetCommentByPostId(long postId);
        Task<IEnumerable<Comment>> GetCommentByUserId(long userId);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);   
    }
}