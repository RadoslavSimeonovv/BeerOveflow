using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }       
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }

    }
}
