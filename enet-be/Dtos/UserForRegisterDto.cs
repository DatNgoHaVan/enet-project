using System;
using System.ComponentModel.DataAnnotations;

namespace enet_be.Dtos
{
    public class UserForRegisterDto
    {
        //this field is required fill in
        [Required]
        public string UserName { get; set; }

        //this field is required fill in
        //only accept between 4 and 32 characters in this field
        [Required]
        [StringLength (32, MinimumLength=4, ErrorMessage="You must specify password between 4 and 32 characters")]
        public string Password { get; set; }
    
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime Birthday { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
    }
}