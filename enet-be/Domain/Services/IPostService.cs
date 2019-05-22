using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enet_be.Dtos;
using enet_be.Models;

namespace enet_be.Data
{
    public interface IPostService
    {
        Task<IEnumerable<PostForReturnDto>> GetAllPostAsync();
        Task<PostForReturnDto> GetOnePostById(long postId);
        Task<IEnumerable<PostForReturnDto>> GetPostByUserId(long userId);
        Task<Post> GetPostForUpdate(long postId);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(PostForUpdateDto postForUpdate, Post postFromRepository);
        Task DeletePostAsync(Post post);
    }
}