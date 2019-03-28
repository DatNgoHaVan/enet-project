using System;
using System.Threading.Tasks;
using enson_be.Data;
using enson_be.Dtos;
using enson_be.Models;
using Microsoft.AspNetCore.Mvc;

namespace enson_be.Controllers
{
    //use controllerBase because reactjs for view
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _repo;
        public RegisterController(IRegisterRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// create new account
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //save username in lowerCase
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            //check username is already exist
            if (await _repo.UserExist(userForRegisterDto.UserName))
            {
                return BadRequest("This username is already exist");
            }

            //object user to create
            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Address = userForRegisterDto.Address,
                //convert string to datetime with mm/dd/yyyy formats
                Birthday = Convert.ToDateTime(userForRegisterDto.Birthday),
                RoleId = 1
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            //status register success
            return StatusCode(201);
        }
    }
}
