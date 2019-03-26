using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class AvailbleOptions
    {
        [Key]
        public long AvailbleOptionsId { get; set; }
        public string Content { get; set; }
    }
}
