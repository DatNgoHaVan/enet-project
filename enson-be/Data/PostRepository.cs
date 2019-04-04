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

        //Call create method in RepositoryBase
        public async Task CreatePostAsync(Post post)
        {
            Create(post);
            await SaveAsync();
        }

        //Call delete method in RepositoryBase
        public async Task DeletePostAsync(Post post)
        {
            Delete(post);
            await SaveAsync();
        }

        //Get all post 
        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            //create obj posts
            var posts = await FindAllAsync();
            //return posts sort id
            return posts.OrderBy(x => x.PostId);
        }

        //Get one post
        public async Task<Post> GetOnePostById(long postId)
        {
            //get post with post id
            var posts = await FindByConditionAsync(x => x.PostId.Equals(postId));
            //return 1 post and default if empty
            return posts.DefaultIfEmpty(new Post()).FirstOrDefault();
        }

        //get all post of user with user id
        public async Task<IEnumerable<Post>> GetPostByUserId(long userId)
        {
            //get obj post with user id
            var posts = await FindByConditionAsync(x => x.UserId.Equals(userId));
            return posts.OrderBy(x => x.PostId);
        }

        //call update in RepoBase
        public async Task UpdatePostAsync(Post post)
        {
            Update(post);
            await SaveAsync();
        }
    }
}