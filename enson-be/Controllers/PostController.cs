using System;
using System.Threading.Tasks;
using enson_be.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace enson_be.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repo;
        private readonly ILogger<PostController> _logger;
        public PostController(IPostRepository repo, ILogger<PostController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                var posts = await _repo.GetAllPostAsync();
                return Ok(posts);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPost: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles="2")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostByIdForAdmin(long id)
        {
            try
            {
                var posts = await _repo.GetOnePostById(id);
                if(posts == null)
                {
                    _logger.LogError($"Post with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else 
                {
                    return Ok(posts);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPostByIdForAdmin action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}