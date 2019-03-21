using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual ListUser ListUser { get; set; }
        public virtual List<Relationship> Relationships { get; set; }
        public virtual List<Appeal> Appeals { get; set; }
        public virtual List<Report> Reports { get; set; }
        public virtual List<Content> Contents { get; set; }
    }
}
