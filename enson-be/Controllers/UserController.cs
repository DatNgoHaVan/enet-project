using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using enson_be.Data;
using enson_be.Dtos;
using enson_be.Helpers;
using enson_be.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace enson_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        private IMapper mapper;
        private readonly AppSettings appSettings;
        public UserController(IUserRepository _userRepository, IMapper _mapper, IOptions<AppSettings> _appSettings)
        {
            userRepository = _userRepository;
            mapper = _mapper;
            appSettings = _appSettings.Value;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = userRepository.GetUsers();
            var usersDto = mapper.Map<IList<UserDto>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            var user = userRepository.GetUserById(id);
            var userDto = mapper.Map<UserDto>(user);
            return Ok(userDto);            
        }

        [HttpPost]
        public IActionResult AddUser([FromBody]UserDto userDto)
        {
            // map dto to models
            var user = mapper.Map<User>(userDto);
            try
            {
                // save
                userRepository.AddUser(user, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, [FromBody]UserDto userDto)
        {
            // map dto to models and set id
            var user = mapper.Map<User>(userDto);
            user.UserId = id;

            try
            {
                // save
                userRepository.UpdateUser(user, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            userRepository.DeleteUser(id);
            return Ok();            
        }
    }
}
