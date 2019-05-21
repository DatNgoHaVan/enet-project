using System;

namespace enet_be.Dtos
{
    public class CommentForCreationDto
    {
        public string Content { get; set; }

        public string Image { get; set; }

        public long UserId { get; set; }
        
        public long PostId { get; set; }
    }
}