using System;
using enson_be.Models;

namespace enson_be.Dtos
{
    // This class contains information serve for Comment, Post
    public class UserForSubReturnDto
    {
        public UserForSubReturnDto(User user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthday = user.Birthday;
        }
        public long UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }
    }
}