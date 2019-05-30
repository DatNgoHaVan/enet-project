using System;
using System.Threading.Tasks;
using enet_be.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using enet_be.Dtos;
using enet_be.Models;
using AutoMapper;
using enet_be.Helpers;
using System.Collections.Generic;

namespace enet_be.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;
        private readonly ILogger<PostController> _logger;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, ILogger<PostController> logger, IMapper mapper)
        {
            _postService = postService;
            _logger = logger;
            _mapper = mapper;
        }

        //get all post only for admin
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                var posts =  await _postService.GetAllPostAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPost: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //get post id only for admin
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("{postId}")]
        public async Task<IActionResult> GetPostById(long id)
        {
            try
            {
                var posts = await _postService.GetOnePostById(id);
                //var resources = _mapper.Map<Post, PostForReturnDto>(posts);
                if (posts == null || posts.PostId.Equals("0"))
                {
                    _logger.LogError($"Post with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    return Ok(posts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPostByIdForAdmin action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //get post by user id for user and admin
        //! This will be change because it shows all post, hasn't solve some logic yet.
        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetPostByUserId(long userId)
        {
            try
            {
                var posts = await _postService.GetPostByUserId(userId);
                if (posts == null)
                {
                    _logger.LogError($"Post of user id: {userId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    return Ok(posts);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPostByUserId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //create post for both admin and user
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        //map 1 json from body to DTO
        public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto postForCreationDto)
        {
            try
            {
                if (postForCreationDto == null)
                {
                    _logger.LogError("Post object sent from client is null");
                    return BadRequest("Post object is null");
                }
                else
                {
                    //create post obj for creation
                    var postToCreate = new Post
                    {
                        Type = postForCreationDto.Type,
                        Url = postForCreationDto.Url,
                        Content = postForCreationDto.Content,
                        Status = postForCreationDto.Status,
                        UserId = postForCreationDto.UserId,
                        AvailableOptionsId = postForCreationDto.AvailableOptionsId
                    };
                    await _postService.CreatePostAsync(postToCreate);
                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //Update post for admin and user
        [Authorize(Roles = "User,Admin")]
        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(long postId, [FromBody] PostForUpdateDto postForUpdateDto)
        {
            try
            {
                if (postForUpdateDto == null)
                {
                    _logger.LogError("Post object sent from client is null");
                    return BadRequest("Post object is null");
                }

                var postFromRepository = await _postService.GetPostForUpdate(postId);

                if (postFromRepository == null)
                {
                    _logger.LogError($"Post with id: {postId}, hasn't been found in db.");
                    return NotFound();
                }

                else
                {
                    //create Post obj for update
                    // var postForUpdate = new Post();
                    //set postForUpdate by map postForUpdateDto and postFromRepo
                    //postForUpdate = _mapper.Map(postForUpdateDto, postFromRepo);
                    await _postService.UpdatePostAsync(postForUpdateDto, postFromRepository);
                    return StatusCode(200);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatePost action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //Delete post for admin an user
        [Authorize(Roles = "User,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            try
            {
                var postForDelete = await _postService.GetOnePostById(id);
                if (postForDelete == null)
                {
                    _logger.LogError($"Post with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                //await _postService.DeletePostAsync(postForDelete);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}