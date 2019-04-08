using enson_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Data
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task DeleteUserAsync(User user)
        {
            Delete(user);
            await SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var users = await FindAllAsync();
            return users.OrderBy(x => x.UserName);
        }

        public async Task<User> GetUserByIdAsync(long userId)
        {
            var user = await FindByConditionAsync(x => x.UserId.Equals(userId));
            return user.DefaultIfEmpty(new User()).FirstOrDefault();
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

            Update(user);
            await SaveAsync();         
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
