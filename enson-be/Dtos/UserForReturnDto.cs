using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enson_be.Models;

namespace enson_be.Dtos
{
    public class UserForReturnDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long RoleId { get; set; }

        public UserForReturnDto()
        {
            
        }
        public UserForReturnDto(User user)
        {
            UserName = user.UserName;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            RoleId = user.RoleId;
        }

    }
}
