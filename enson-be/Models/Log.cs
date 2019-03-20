using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Log
    {
        public long LogId { get; set; }
        public string Content { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ModifiedBy { get; set; }
    }
}
