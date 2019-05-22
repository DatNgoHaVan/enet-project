﻿using System;
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

        // get user by id

        [Authorize(Roles = "1,2")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(long userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);

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

        [Authorize(Roles = "1,2")]
        [HttpGet("getByEmail/{userEmail}")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(userEmail);

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

        [Authorize(Roles = "1,2")]
        [HttpGet("getByUserName/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            try
            {
                var user = await _userRepository.GetUserByUserNameAsync(userName);

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
                    if(userName != user.UserName)
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
                    return StatusCode(404, "Not found!");
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