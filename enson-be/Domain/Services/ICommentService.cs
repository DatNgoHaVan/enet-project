using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Domain.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAllCommentAsync();
        Task<Comment> GetCommentById(long commentId);
        Task<IEnumerable<Comment>> GetCommentByPostId(long postId);
        Task<IEnumerable<Comment>> GetCommentByUserId(long userId);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);
    }
}