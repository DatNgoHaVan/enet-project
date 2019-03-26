using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Expect
    {
        [Key]
        [Column(Order = 1)]
        public long UserIdMain { get; set; }
        [Key]
        [Column(Order = 2)]
        public long UserIdSub { get; set; }
           
        // UserIdMain and UserIdSub are from table User so we need User1 and User2
        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
