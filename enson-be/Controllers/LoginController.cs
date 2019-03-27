using System.Threading.Tasks;
using enson_be.Data;
using enson_be.Dtos;
using enson_be.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace enson_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repo;
        private readonly IConfiguration _config;
        public LoginController(ILoginRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            //get user from repository
            var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);

            //check user is null
            if (userFromRepo == null)
                return Unauthorized();

            //create claim for JWT
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };


        }

    }
}