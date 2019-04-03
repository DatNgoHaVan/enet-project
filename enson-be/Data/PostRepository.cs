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

        public async Task CreatePostAsync(Post post)
        {
            Create(post);
            await SaveAsync();
        }

        public async Task DeletePostAsync(Post post)
        {
            Delete(post);
            await SaveAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            var posts = await FindAllAsync();
            return posts.OrderBy(x => x.PostId);
        }

        public async Task<Post> GetOnePostById(long postId)
        {
            var posts = await FindByConditionAsync(o => o.PostId.Equals(postId));
            return posts.DefaultIfEmpty(new Post())
                    .FirstOrDefault();
        }

        public async Task<IEnumerable<Post>> GetPostByUserId(long userId)
        {
            var posts = await FindByConditionAsync(x => x.UserId == userId);
            return posts;
        }

        public async Task UpdatePostAsync(Post post)
        {
            Update(post);
            await SaveAsync();
        }
    }
}