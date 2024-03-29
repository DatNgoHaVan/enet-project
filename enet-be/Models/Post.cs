﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long PostId { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public int? Status { get; set; }
        public bool IsExist { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Reaction> Reactions { get; set; }
        public virtual List<Report> Reports { get; set; }
        public long AvailableOptionsId { get; set; }
        public virtual AvailableOptions AvailableOptions { get; set; }
        public virtual List<OptionPostUser> OptionPostUsers { get; set; }
    }
}
