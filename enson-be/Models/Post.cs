using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Post
    {
        [Required]
        public long PostId { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Reaction> Reactions { get; set; }
        public virtual List<Report> Reports { get; set; }
        public long AvailbleOptionsId { get; set; }
        public AvailbleOptions AvailbleOptions { get; set; }
        public virtual List<OptionPostUser> OptionPostUsers { get; set; }
    }
}
