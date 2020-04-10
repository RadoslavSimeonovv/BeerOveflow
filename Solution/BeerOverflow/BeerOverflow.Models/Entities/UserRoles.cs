using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class UserRoles
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }

    }
}
