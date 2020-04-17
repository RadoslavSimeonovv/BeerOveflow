using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class UserBeersViewModel
    {
        public String User { get; set; }
        public int UserId { get; set; }

        public String Beer { get; set; }
        public int BeerId { get; set; }

        public DateTime? DrankOn { get; set; }
    }
}
