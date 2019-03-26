using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class ReportType
    {
        [Key]
        public long ReportTypeId { get; set; }
        public string ReportTypeName { get; set; }
        public virtual List<Report> Reports { get; set; }
    }
}
