using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using enson_be.Dtos;
using enson_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enson_be.Data
{
    public class PostService : IPostService
    {
        private readonly IRepositoryBase<Post> _postRepository;

        public PostService(IRepositoryBase<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
        }

        //Call create method in RepositoryBase
        public async Task CreatePostAsync(Post post)
        {
            _postRepository.Create(post);
            await _postRepository.SaveAsync();
        }

        //Call delete method in RepositoryBase
        public async Task DeletePostAsync(Post post)
        {
            _postRepository.Delete(post);
            await _postRepository.SaveAsync();
        }

        //Get all post 
        public async Task<IEnumerable<Post>> GetAllPostAsync()
        {
            var postsToReturn = await _postRepository.FindAll()
                            .Include(x => x.AvailableOptions)
                            .Include(x => x.User)
                            .Include(x => x.Comments)
                            .ThenInclude(p => p.User)
                            .OrderBy(x => x.PostId)
                            .ToListAsync();
            // .Select(x => new PostForReturnDto
            // {
            //     PostId = x.PostId,
            //     Type = x.Type,
            //     Url = x.Url,
            //     Content = x.Content,
            //     Status = x.Status,
            //     UserId = x.UserId,
            //     AvailableOptions = x.AvailableOptions,
            //     //User = new UserForReturnDto(x.User),
            //     //Comments = x.Comments.Select(y => new CommentForReturnDto().FromEntity(y)).ToList()
            // });
            return postsToReturn;
        }

        //Get one post
        public async Task<Post> GetOnePostById(long postId)
        {
            //get post with post id
            var postToReturn = await _postRepository
                            .FindByCondition(x => x.PostId.Equals(postId))
                            .Include(x => x.AvailableOptions)
                            .Include(x => x.User)
                            .Include(x => x.Comments)
                            .ThenInclude(p => p.User)
                            .ToListAsync();
            //return 1 post and default if empty
            return postToReturn.DefaultIfEmpty().FirstOrDefault();
        }

        //get all post of user with user id
        public async Task<IEnumerable<Post>> GetPostByUserId(long userId)
        {
            //get obj post with user id
            var postsToReturn = await _postRepository
                            .FindByCondition(x => x.UserId.Equals(userId))
                            .Include(x => x.AvailableOptions)
                            .Include(x => x.User)
                            .Include(x => x.Comments)
                            .ThenInclude(p => p.User)
                            .OrderBy(x => x.PostId)
                            .ToListAsync();
            return postsToReturn;

        }

        //call update in RepoBase
        public async Task UpdatePostAsync(Post post)
        {
            _postRepository.Update(post);
            await _postRepository.SaveAsync();
        }
    }
}