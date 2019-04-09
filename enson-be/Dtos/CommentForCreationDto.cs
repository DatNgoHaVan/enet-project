using System;

namespace enson_be.Dtos
{
    public class CommentForCreationDto
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public long UserId { get; set; }
        public long PostId { get; set; }
    }
}