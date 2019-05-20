using System.Collections.Generic;
using enson_be.Models;

namespace enson_be.Dtos
{
    public class PostForReturnDto
    {
        public long PostId { get; set; }
        
        public string Type { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public int? Status { get; set; }

        public UserForSubReturnDto User { get; set; }

        public AvailableOptions AvailableOptions { get; set; }

        public List<CommentForSubReturnDto> Comments { get; set; }
    }
}