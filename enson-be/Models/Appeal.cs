using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Appeal
    {
        public long AppealId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }        
        public long ReportId { get; set; }
        public Report Report { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
