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
        private IUserRepository _userRepository;
        private ILogger<UserController> _logger;
        private IMapper _mapper;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUserAsync();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(long userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);

                // check null
                if (user == null)
                {
                    _logger.LogError($"User with userId: {userId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "1,2")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(long userId, [FromBody]UserForUpdateDto userForUpdateDto)
        {

            try
            {
                // find user with id
                var user = await _userRepository.GetUserByIdAsync(userId);

                // check null user
                if (user == null)
                {
                    _logger.LogError($"User with userId: {userId}, hasn't been found in db.");
                    return NotFound();
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
                    await _userRepository.UpdateUserAsync(userForUpdate, userForUpdateDto.Password);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                // check null user
                if (user == null)
                {
                    _logger.LogError($"User with userId: {userId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    await _userRepository.DeleteUserAsync(user);
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
