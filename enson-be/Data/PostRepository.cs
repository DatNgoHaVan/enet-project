using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using enson_be.Dtos;
using enson_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enson_be.Data
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        private readonly IMapper _mapper;

        public PostRepository(DatabaseContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
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
        public List<PostForReturnDto> GetAllPostAsync()
        {
            //create obj posts
            //var posts = await FindAllAsync();
            //return posts sort id
            //return posts.OrderBy(x => x.PostId);           
            var posts = FindAsQueryable()
                .Select(x => new PostForReturnDto
                {
                    PostId = x.PostId,
                    Type = x.Type,
                    Url = x.Url,
                    Content = x.Content,
                    Status = x.Status,
                    UserId = x.UserId,
                    AvailableOptions = x.AvailableOptions,
                    //User = new UserForReturnDto(x.User),
                    Comments = x.Comments.Select(y => new CommentForReturnDto().FromEntity(y)).ToList()
                });
            return posts.ToList();
        }

        //Get one post
        public async Task<Post> GetOnePostById(long postId)
        {
            //get post with post id
            //var posts = await FindByConditionAsync(x => x.PostId.Equals(postId));
            var posts = await _context.Posts
                .Include(x => x.AvailableOptions)
                .Include(x => x.User)
                .Where(x => x.PostId.Equals(postId))
                .Include(x => x.Comments)
                .ToListAsync();
            //return 1 post and default if empty
            return posts.DefaultIfEmpty().FirstOrDefault();
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