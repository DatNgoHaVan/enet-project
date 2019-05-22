using System;
using System.Threading.Tasks;
using enet_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enet_be.Data
{
    public class LoginService:ILoginService
    {
        private readonly DatabaseContext _context;
        public LoginService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            //get user from username in database
            var user = await _context.Users.Include(x=>x.Role).FirstOrDefaultAsync(x => x.UserName == username);

            //check user is null
            if (user == null)
            {
                return null;
            }

            //verify password with hash
            if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        //verify password method
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //generate hmac with passwordSalt is in db
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //computeHash constrain password which was inputed by user was hash with salt
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //loop for checking with passwordHash in db
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}