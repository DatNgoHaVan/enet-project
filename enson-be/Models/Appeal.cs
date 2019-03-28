using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Appeal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long AppealId { get; set; }
        public DateTime? Date { get; set; }
        public int? Status { get; set; }      
        
        // foreign key in table appeal
        public long ReportId { get; set; }
        public Report Report { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
