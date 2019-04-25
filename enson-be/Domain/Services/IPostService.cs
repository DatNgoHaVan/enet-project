using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Dtos;
using enson_be.Models;

namespace enson_be.Data
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostAsync();
        Task<Post> GetOnePostById(long postId);
        Task<IEnumerable<Post>> GetPostByUserId(long userId);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(Post post);
    }
}