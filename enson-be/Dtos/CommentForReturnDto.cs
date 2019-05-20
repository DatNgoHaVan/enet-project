using System;
using System.Collections.Generic;
using enson_be.Models;

namespace enson_be.Dtos
{
    public class CommentForReturnDto
    {
        public long CommentId { get; set; }

        public DateTime? Date { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public long UserId { get; set; }

        public UserForSubReturnDto User { get; set; }

        public long PostId { get; set; }
    }
}