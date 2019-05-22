using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
{
    public class Relationship
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long RelationshipId { get; set; }
        public long UserId { get; set; }        
        public long UserSub { get; set; }
        public Boolean? Friend { get; set; }
        public Boolean? Follow { get; set; }
        public Boolean? Block { get; set; }
        public virtual User User { get; set; }
    }
}
