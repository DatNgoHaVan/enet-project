using System;

namespace enson_be.Dtos
{
    // This class contains information serve for Comment, Post
    public class UserForSubReturnDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public DateTime? Birthday { get; set; }
    }
}