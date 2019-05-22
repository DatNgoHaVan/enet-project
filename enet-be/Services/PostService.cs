using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using enet_be.Dtos;
using enet_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enet_be.Data
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
        public async Task<IEnumerable<PostForReturnDto>> GetAllPostAsync()
        {
            var postsToReturn = await _postRepository.FindAll()
                            .Select(x => new PostForReturnDto
                            {
                                PostId = x.PostId,
                                Type = x.Type,
                                Url = x.Url,
                                Content = x.Content,
                                Status = x.Status,
                                User = new UserForSubReturnDto(x.User),
                                Comments = x.Comments.Select(p => new CommentForSubReturnDto().FromEntity(p, p.User)).ToList(),
                                AvailableOptions = x.AvailableOptions,
                            })
                            .ToListAsync();
            return postsToReturn;
        }

        //Get one post
        public async Task<PostForReturnDto> GetOnePostById(long postId)
        {
            //get post with post id
            var postToReturn = await _postRepository
                            .FindByCondition(x => x.PostId.Equals(postId))
                            .Select(x => new PostForReturnDto
                            {
                                PostId = x.PostId,
                                Type = x.Type,
                                Url = x.Url,
                                Content = x.Content,
                                Status = x.Status,
                                User = new UserForSubReturnDto(x.User),
                                Comments = x.Comments.Select(p => new CommentForSubReturnDto().FromEntity(p, p.User)).ToList(),
                                AvailableOptions = x.AvailableOptions,
                            })
                            // .ThenInclude(p => p.User)
                            .ToListAsync();
            //return 1 post and default if empty
            return postToReturn.DefaultIfEmpty().SingleOrDefault();
        }

        //get all post of user with user id
        public async Task<IEnumerable<PostForReturnDto>> GetPostByUserId(long userId)
        {
            //get obj post with user id
            var postsToReturn = await _postRepository
                            .FindByCondition(x => x.UserId.Equals(userId))
                            .Select(x => new PostForReturnDto
                            {
                                PostId = x.PostId,
                                Type = x.Type,
                                Url = x.Url,
                                Content = x.Content,
                                Status = x.Status,
                                User = new UserForSubReturnDto(x.User),
                                Comments = x.Comments.Select(p => new CommentForSubReturnDto().FromEntity(p, p.User)).ToList(),
                                AvailableOptions = x.AvailableOptions,
                            })
                            .OrderBy(x => x.PostId)
                            .ToListAsync();
            return postsToReturn;

        }

        //call update in RepoBase
        public async Task UpdatePostAsync(PostForUpdateDto postForUpdate)
        {
            var post = new Post();
            _postRepository.Update(post);
            await _postRepository.SaveAsync();
        }
    }
}