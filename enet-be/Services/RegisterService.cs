using System;
using System.Threading.Tasks;
using enet_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enet_be.Data
{
    public class RegisterService : IRegisterService
    {
        private readonly DatabaseContext _context;

        //create constructor for RegisterRepository
        /**Note: Once its added here we can then make use of the DatabaseContext inside 
        any of our classes by injecting it into the class constructor  */
        /*as anything inside the ConfigureServices method inside the Startup.cs class 
        will be available to be used (injected) into other parts of our application. */
        public RegisterService (DatabaseContext context) 
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {
            //declare passwordHash and passwordSalt
            byte[] passwordHash, passwordSalt;
            //run create password hash
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //save passwordHash and salt to user
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            //role id of user is 1 by default
            user.RoleId = 1;

            //insert user to database 
            await _context.Users.AddAsync(user);
            //waiting for inserting user to db then save
            await _context.SaveChangesAsync();

            return user;
        }

        /**Hash password */
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            /**return passwordHash and passwordSalt */
            /*Auto generate key hmac */
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //Hash the password with HMACSHA512
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //A secret key was auto generated
                passwordSalt = hmac.Key;
            }
        }

        public async Task<bool> UserExist(string username)
        {
            /*Compare with every username in db */
            if (await _context.Users.AnyAsync(x => x.UserName == username))
                return true;
            return false;
        }

        public async Task<bool> EmailExist(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email == email))
                return true;
            return false;
        }
    }
}