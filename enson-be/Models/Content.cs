using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Content
    {
        public long ContentId { get; set; }
        public string ContentName { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public virtual List<Report> Reports { get; set; }
    }
}
