using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Data
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(DatabaseContext context) : base(context)
        {
        }

        public Task CreatePostAsync(Post post)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletePostAsync(Post post)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            var posts = await FindAllAsync();
            return posts.OrderBy(x => x.PostId);
        }

        public async Task<Post> GetOnePostById(long postId)
        {
            var posts = await FindOne(x => x.PostId == postId);
            return posts; 
        }

        public Task<IEnumerable<Post>> GetPostByUserId(long userId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdatePostAsync(long postId, Post post)
        {
            throw new System.NotImplementedException();
        }
    }
}