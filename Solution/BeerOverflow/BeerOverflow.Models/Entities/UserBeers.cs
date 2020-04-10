using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class UserBeers
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public Beer Beer { get; set; }
        public int BeerId { get; set; }

        public DateTime? DrankOn { get; set; }
    }
}
