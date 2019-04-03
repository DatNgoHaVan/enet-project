using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Dtos;
using enson_be.Helpers;
using enson_be.Models;
using Microsoft.EntityFrameworkCore;

namespace enson_be.Data
{
    public class UserRepository : IUserRepository
    {
        DatabaseContext db;
        public UserRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        }

        public User GetUserById(long userId)
        {
            return db.Users.Find(userId);
        }

        public User AddUser(User user, string password)
        {
            // validation 
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is not required");
            }

            if (db.Users.Any(x => x.UserName == user.UserName))
            {
                throw new AppException("Username \"" + user.UserName + "\" is already taken");
            }

            // create two Variable for password: hash and salt 
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            //role id of user is 1 by default
            user.RoleId = 1;

            // add user
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }        

        public void UpdateUser(User userParam, string password = null)
        {
            var user = db.Users.Find(userParam.UserId);

            if(user == null)
            {
                throw new AppException("User not found");
            }

            if(userParam.UserName != user.UserName)
            {
                // username has changed so check if the new username is already taken
                if (db.Users.Any(x => x.UserName == userParam.UserName))
                {
                    throw new AppException("Username \"" + user.UserName + "\" is already taken");
                }
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.UserName = userParam.UserName;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            // update user
            db.Users.Update(user);
            db.SaveChanges();
        }

        public void DeleteUser(long userId)
        {
            var user = db.Users.Find(userId);
            if(user != null)
            {
                // delete user
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        // private helper methods for password

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
