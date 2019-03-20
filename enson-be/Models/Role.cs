using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class Role
    {
        public long RoleId { get; set; }
        public string Type { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
