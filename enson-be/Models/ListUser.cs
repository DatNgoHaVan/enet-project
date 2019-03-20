using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class ListUser
    {
        [Key, ForeignKey("User")]
        public long UserID { get; set; }
        public string Except { get; set; }
        public string Only { get; set; }
        public virtual User User { get; set; }
    }
}
