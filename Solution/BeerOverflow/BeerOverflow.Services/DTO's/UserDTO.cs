using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }


    }
}
