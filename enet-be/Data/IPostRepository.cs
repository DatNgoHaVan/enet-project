using System.Collections.Generic;
using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostAsync();
        Task<Post> GetOnePostById(long postId);
        Task<IEnumerable<Post>> GetPostByUserId(long userId);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(Post post);
    }
}