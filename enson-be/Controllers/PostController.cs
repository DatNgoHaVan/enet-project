using System;
using System.Threading.Tasks;
using enson_be.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using enson_be.Dtos;
using enson_be.Models;
using AutoMapper;
using enson_be.Helpers;

namespace enson_be.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repo;
        private readonly ILogger<PostController> _logger;
        private readonly IMapper _mapper;

        public PostController(IPostRepository repo, ILogger<PostController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _repo = repo;
        }

        //get all post only for admin
        [Authorize(Roles = "2")]
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                var posts = await _repo.GetAllPostAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPost: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //get post id only for admin
        [Authorize(Roles = "2")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostByIdForAdmin(long id)
        {
            try
            {
                var posts = await _repo.GetOnePostById(id);
                if (posts == null)
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
        [Authorize(Roles = "1,2")]
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetPostByUserId(long userId)
        {
            try
            {
                var posts = await _repo.GetPostByUserId(userId);
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
        [Authorize(Roles = "1,2")]
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
                    await _repo.CreatePostAsync(postToCreate);
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
        [Authorize(Roles = "1,2")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(long id, [FromBody] PostForUpdateDto postForUpdateDto)
        {
            try
            {
                if (postForUpdateDto == null)
                {
                    _logger.LogError("Post object sent from client is null");
                    return BadRequest("Post object is null");
                }

                var postFromRepo = await _repo.GetOnePostById(id);

                if (postFromRepo == null)
                {
                    _logger.LogError($"Post with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                else
                {
                    //create Post obj for update
                    var postForUpdate = new Post();
                    //set postForUpdate by map postForUpdateDto and postFromRepo
                    postForUpdate = _mapper.Map(postForUpdateDto, postFromRepo);
                    await _repo.UpdatePostAsync(postForUpdate);
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
        [Authorize(Roles = "1,2")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            try
            {
                var postForDelete = await _repo.GetOnePostById(id);
                if (postForDelete == null)
                {
                    _logger.LogError($"Post with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await _repo.DeletePostAsync(postForDelete);

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