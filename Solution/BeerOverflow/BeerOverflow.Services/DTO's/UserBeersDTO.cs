using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class UserBeersDTO
    {
        public String User { get; set; }
        public int UserId { get; set; }

        public String Beer { get; set; }
        public int BeerId { get; set; }

        public DateTime? DrankOn { get; set; }
    }
}
