using System;
using enson_be.Models;

namespace enson_be.Dtos
{
    public class CommentForSubReturnDto
    {
        public long CommentId { get; set; }

        public DateTime? Date { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public UserForSubReturnDto User { get; set; }

        public CommentForSubReturnDto FromEntity(Comment comment, User user)
        {
            return new CommentForSubReturnDto()
            {
                CommentId = comment.CommentId,
                Date = comment.Date,
                Content = comment.Content,
                Image = comment.Image,
                User = new UserForSubReturnDto(user),
                //PostId = comment.PostId,
                //User = new UserForReturnDto(comment.User) 
            };
        }
    }
}