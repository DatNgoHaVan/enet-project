using System;
using System.Threading.Tasks;
using AutoMapper;
using enson_be.Data;
using enson_be.Dtos;
using enson_be.Models;
using enson_be.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace enson_be.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repo;
        private readonly ILogger<CommentController> _logger;
        private readonly IMapper _map;

        public CommentController(ICommentRepository repo, ILogger<CommentController> logger, IMapper map)
        {
            _repo = repo;
            _logger = logger;
            _map = map;
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            try
            {
                var comments = await _repo.GetAllCommentAsync();
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPost: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCommentById(long id)
        {
            try
            {
                //comments object from db
                var comments = await _repo.GetCommentById(id);

                if (comments == null)
                {
                    _logger.LogError($"Comment with ID: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned Comment with ID: {id}");
                    return Ok(comments);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCommentById action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        [Route("getByPostId/{postId}")]
        public async Task<IActionResult> GetCommentByPostId(long postId)
        {
            try
            {
                var comments = await _repo.GetCommentByPostId(postId);
                if (comments == null)
                {
                    _logger.LogError($"Comments of Post with ID: {postId}, hasn't been found ib db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned Comment of Post with ID: {postId}");
                    return Ok(comments);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCommentByPostId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        [Route("getByUserId/{userId}")]
        public async Task<IActionResult> GetCommentByUserId(long userId)
        {
            try
            {
                var comments = await _repo.GetCommentByUserId(userId);

                if (comments == null)
                {
                    _logger.LogError($"Comments of User with ID: {userId}, hasn't been found in db");
                    return NotFound();
                }

                else
                {
                    _logger.LogInformation($"Returned Comments of User with ID: {userId}");
                    return Ok(comments);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCommentByUserId action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentForCreationDto commentForCreationDto)
        {
            try
            {
                if (commentForCreationDto == null)
                {
                    _logger.LogError("Comment object sent from client is null");
                    return BadRequest("Comment object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Comment object sent from client");
                    return BadRequest("Invalid model object");
                }

                else
                {
                    var commentForCreate = new Comment
                    {
                        Date = DateTime.Now,
                        Content = commentForCreationDto.Content,
                        Image = commentForCreationDto.Image,
                        UserId = commentForCreationDto.UserId,
                        PostId = commentForCreationDto.PostId
                    };
                    await _repo.CreateCommentAsync(commentForCreate);
                    _logger.LogInformation("A Comment has been created");
                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateComment action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "2")]
        [HttpPut]
        public async Task<IActionResult> UpdateComment(long commentId, [FromBody] CommentForUpdateDto commentForUpdateDto)
        {
            try
            {
                if (commentForUpdateDto == null)
                {
                    _logger.LogError("Comment object sent from client is null");
                    return BadRequest("Comment object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Comment object sent from client");
                    return BadRequest("Invalid Comment object");
                }

                //get commentobject from db
                var commentFromRepo = await _repo.GetCommentById(commentId);

                if (commentFromRepo == null)
                {
                    _logger.LogError($"Comment with ID:{commentId}, hasn't been found in db");
                    return NotFound();
                }

                else
                {
                    var commentForUpdate = new Comment();
                    commentForUpdate = _map.Map(commentForUpdateDto, commentFromRepo);
                    await _repo.UpdateCommentAsync(commentForUpdate);
                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateComment action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "2")]
        [HttpDelete]
        public async Task<IActionResult> DeleteComment(long commentId)
        {
            try
            {
                var commentForDelete = await _repo.GetCommentById(commentId);
                
                if(commentForDelete == null)
                {
                    _logger.LogError($"Comment with ID:{commentId}, hasn't been found in db.");
                    return NotFound();
                }

                else{
                    await _repo.DeleteCommentAsync(commentForDelete);
                    _logger.LogInformation("A Comment has been deleted");
                    return StatusCode(201);
                }
            }
            catch(Exception ex){
                _logger.LogError($"Something went wrong inside DeleteComment action: {ex.Message}");
                return StatusCode(500,"Internal server error");
            }
        }
    }
}