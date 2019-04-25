using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Dtos
{
    public class UserForReturnDto
    {
        public long UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime? Birthday { get; set; }

        public long RoleId { get; set; }

        public RoleForSubReturn Role { get; set; }
    }
}
