using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
{
    public class AvailableOptions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long AvailableOptionsId { get; set; }
        public string Content { get; set; }
    }
}
