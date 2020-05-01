using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class User : IdentityUser<int>
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool isBanned { get; set; }
        public string banDescription { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }

    }
}
