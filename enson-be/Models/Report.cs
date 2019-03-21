using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Report
    {
        public long ReportId { get; set; }
        public long ReporterId { get; set; }
        public int Type { get; set; }
        public long ContentId { get; set; }
        public long BeReportedId { get; set; }
        public long Judge { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public int Status { get; set; }
        public int Count { get; set; }
        public virtual List<Appeal> Appeals { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public Content Content { get; set; }
    }
}
