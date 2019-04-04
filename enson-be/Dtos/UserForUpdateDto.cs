using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Dtos
{
    public class UserForUpdateDto
    {
        public string UserName { get; set; }

        //this field is required fill in
        //only accept between 4 and 32 characters in this field
        [StringLength(32, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 32 characters")]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
