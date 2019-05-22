using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
{
    public class Reaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ReactionId { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public virtual Post Post { get; set; }
    }
}
