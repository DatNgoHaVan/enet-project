using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
{
    public class Content
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ContentId { get; set; }
        public string ContentName { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public virtual List<Report> Reports { get; set; }
    }
}
