using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Dtos;
using enson_be.Models;

namespace enson_be.Data
{
    public interface IPostService
    {
        Task<IEnumerable<PostForReturnDto>> GetAllPostAsync();
        Task<PostForReturnDto> GetOnePostById(long postId);
        Task<IEnumerable<PostForReturnDto>> GetPostByUserId(long userId);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(PostForUpdateDto postForUpdate);
        Task DeletePostAsync(Post post);
    }
}