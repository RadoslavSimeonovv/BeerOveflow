using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class ReviewViewModel
    {
        public string RMessage { get; set; }
        public int Rating { get; set; }
        public DateTime? ReviewedOn { get; set; }
        //public DateTime? DeletedOn { get; set; }

        public String BeerName { get; set; }
        public int BeerId { get; set; }

        public String UserName { get; set; }
        public int UserId { get; set; }
    }
}
