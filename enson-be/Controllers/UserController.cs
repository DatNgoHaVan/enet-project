using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using enson_be.Data;
using enson_be.Dtos;
using enson_be.Helpers;
using enson_be.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace enson_be.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ILogger<UserController> _logger;
        private IMapper _mapper;

        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUserAsync();
                var resources = _mapper.Map<IEnumerable<User>,IEnumerable<UserForReturnDto>>(users);
                return Ok(resources);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // get user by id

        [Authorize(Roles = "User, Admin")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(long userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);

                // return without password
                user.PasswordHash = null;
                user.PasswordSalt = null;

                // check null
                if (user == null)
                {
                    _logger.LogError($"User with userId: {userId}, hasn't been found in db.");
                    return StatusCode(404, "Not found!");
                }
                else
                {
                    if (userId != user.UserId)
                    {
                        return StatusCode(404, "Not found!");
                    }
                    return Ok(user);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // get user by email

        [Authorize(Roles = "User, Admin")]
        [HttpGet("getByEmail/{userEmail}")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(userEmail);

                // return without password
                user.PasswordHash = null;
                user.PasswordSalt = null;

                // check null
                if (user == null)
                {
                    _logger.LogError($"User with userEmail: {userEmail}, hasn't been found in db.");
                    return StatusCode(404, "Not found!");
                }
                else
                {
                    if (userEmail != user.Email)
                    {
                        return StatusCode(404, "Not found!");
                    }
                    return Ok(user);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // get user by username

        [Authorize(Roles = "User,Admin")]
        [HttpGet("getByUserName/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            try
            {
                var user = await _userService.GetUserByUserNameAsync(userName);

                // return without password
                user.PasswordHash = null;
                user.PasswordSalt = null;

                // check null
                if (user == null)
                {
                    _logger.LogError($"User with userName: {userName}, hasn't been found in db.");
                    return StatusCode(404, "Not found!");
                }
                else
                {
                    if (userName != user.UserName)
                    {
                        return StatusCode(404, "Not found!");
                    }
                    return Ok(user);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(long userId, [FromBody]UserForUpdateDto userForUpdateDto)
        {

            try
            {
                // find user with id
                var user = await _userService.GetUserByIdAsync(userId);

                // check null user
                if (user == null)
                {
                    _logger.LogError($"User with userId: {userId}, hasn't been found in db.");
                    return StatusCode(404, "Not found!");
                }
                else
                {
                    // update user property
                    var userForUpdate = new User()
                    {
                        UserName = userForUpdateDto.UserName,
                        Email = userForUpdateDto.Email,
                        FirstName = userForUpdateDto.FirstName,
                        LastName = userForUpdateDto.LastName,
                        RoleId = 1
                    };
                    // map
                    userForUpdate = _mapper.Map(userForUpdateDto, user);
                    await _userService.UpdateUserAsync(userForUpdate, userForUpdateDto.Password);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(userId);
                // check null user
                if (user == null)
                {
                    _logger.LogError($"User with userId: {userId}, hasn't been found in db.");
                    return StatusCode(404, "Not found!");
                }
                else
                {
                    await _userService.DeleteUserAsync(user);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
