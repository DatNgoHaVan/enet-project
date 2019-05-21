using System;
using System.Threading.Tasks;
using AutoMapper;
using enet_be.Data;
using enet_be.Dtos;
using enet_be.Models;
using enet_be.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using enet_be.Domain.Services;

namespace enet_be.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        private readonly ILogger<CommentController> _logger;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger, IMapper mapper)
        {
            _commentService = commentService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            try
            {
                var comments = await _commentService.GetAllCommentAsync();
                var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentForReturnDto>>(comments);
                return Ok(resources);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPost: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}", Name = "GetComment")]
        public async Task<IActionResult> GetCommentById(long id)
        {
            try
            {
                //comments object from db
                var comments = await _commentService.GetCommentById(id);

                if (comments == null)
                {
                    _logger.LogError($"Comment with ID: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var resources = _mapper.Map<Comment, CommentForReturnDto>(comments);
                    _logger.LogInformation($"Returned Comment with ID: {id}");
                    return Ok(resources);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCommentById action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        [Route("getByPostId/{postId}")]
        public async Task<IActionResult> GetCommentByPostId(long postId)
        {
            try
            {
                var comments = await _commentService.GetCommentByPostId(postId);
                if (comments == null)
                {
                    _logger.LogError($"Comments of Post with ID: {postId}, hasn't been found ib db");
                    return NotFound();
                }
                else
                {
                    var resources = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentForReturnDto>>(comments);
                    _logger.LogInformation($"Returned Comment of Post with ID: {postId}");
                    return Ok(resources);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCommentByPostId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        [Route("getByUserId/{userId}")]
        public async Task<IActionResult> GetCommentByUserId(long userId)
        {
            try
            {
                var comments = await _commentService.GetCommentByUserId(userId);

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

        [Authorize(Roles = "User,Admin")]
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
                    await _commentService.CreateCommentAsync(commentForCreate);
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

        [Authorize(Roles = "Admin")]
        [HttpPut("{commentId}")]
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
                var commentFromRepo = await _commentService.GetCommentById(commentId);

                if (commentFromRepo == null)
                {
                    _logger.LogError($"Comment with ID:{commentId}, hasn't been found in db");
                    return NotFound();
                }

                else
                {
                    var commentForUpdate = new Comment();
                    commentForUpdate = _mapper.Map(commentForUpdateDto, commentFromRepo);
                    await _commentService.UpdateCommentAsync(commentForUpdate);
                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateComment action:{ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(long commentId)
        {
            try
            {
                var commentForDelete = await _commentService.GetCommentById(commentId);

                if (commentForDelete == null)
                {
                    _logger.LogError($"Comment with ID:{commentId}, hasn't been found in db.");
                    return NotFound();
                }

                else
                {
                    await _commentService.DeleteCommentAsync(commentForDelete);
                    _logger.LogInformation("A Comment has been deleted");
                    return StatusCode(201);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteComment action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}