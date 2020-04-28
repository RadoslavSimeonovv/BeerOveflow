using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class UserBeers
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Beer Beer { get; set; }
        public int BeerId { get; set; }

        public DateTime? DrankOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
