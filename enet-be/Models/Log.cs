﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
{
    public class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long LogId { get; set; }
        public string Content { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
