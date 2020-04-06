using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

    }
}
