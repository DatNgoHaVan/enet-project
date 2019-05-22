using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long ReportId { get; set; }
        public long ReporterId { get; set; }
        public int? Type { get; set; }
        public long ContentId { get; set; }
        public long BeReportedId { get; set; }
        public long? Judge { get; set; }
        public DateTime? ReportDate { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? Status { get; set; }
        public int? Count { get; set; }
        public virtual List<Appeal> Appeals { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Content Content { get; set; }
        public long ReportTypeId { get; set; }
        public virtual ReportType ReportType { get; set; }
    }
}
