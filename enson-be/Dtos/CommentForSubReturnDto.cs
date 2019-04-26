using System;

namespace enson_be.Dtos
{
    public class CommentForSubReturnDto
    {
        public long CommentId { get; set; }

        public DateTime? Date { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public long UserId { get; set; }

        public UserForSubReturnDto User { get; set; }
    }
}