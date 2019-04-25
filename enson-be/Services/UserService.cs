using AutoMapper;
using enson_be.Dtos;
using enson_be.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Data
{
    public class UserService : IUserService
    {
        private IRepositoryBase<User> _repo;

        public UserService(IRepositoryBase<User> repo)
        {
            _repo = repo;
        }

        public async Task DeleteUserAsync(User user)
        {
            _repo.Delete(user);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var usersToReturn = await _repo.FindAll().Include(x => x.Role).ToListAsync();
            // return user without password
            return usersToReturn;
        }

        public async Task<User> GetUserByEmailAsync(string userEmail)
        {
            var userToReturn = await _repo
                            .FindByCondition(x => x.Email.Equals(userEmail))
                            .Include(x => x.Role)
                            .ToListAsync();
            return userToReturn.FirstOrDefault();
        }

        public async Task<User> GetUserByIdAsync(long userId)
        {
            var user = await _repo
                            .FindByCondition(x => x.UserId.Equals(userId))
                            .Include(x => x.Role)
                            .ToListAsync();
            return user.DefaultIfEmpty(new User()).FirstOrDefault();
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var userToReturn = await _repo
                            .FindByCondition(x => x.UserName.Equals(userName))
                            .Include(x => x.Role)
                            .ToListAsync();
            return userToReturn.DefaultIfEmpty(new User()).FirstOrDefault();
        }

        public async Task UpdateUserAsync(User user, string password)
        {
            //declare passwordHash and passwordSalt
            byte[] passwordHash, passwordSalt;
            //run create password hash
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //save passwordHash and salt to user
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _repo.Update(user);
            await _repo.SaveAsync();
        }
        /**Hash password */
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            /**return passwordHash and passwordSalt */
            /*Auto generate key hmac */
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //Hash the password with HMACSHA512
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //A secret key was auto generated
                passwordSalt = hmac.Key;
            }
        }
    }
}
