﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Comment
    {
        [Required]
        public long CommentId { get; set; } 
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
