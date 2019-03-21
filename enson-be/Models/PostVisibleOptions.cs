using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class PostVisibleOptions
    {
        [Key, ForeignKey("Post")]
        public long PostId { get; set; }
        public string ListUser { get; set; }
        public Post Post { get; set; }
    }
}
