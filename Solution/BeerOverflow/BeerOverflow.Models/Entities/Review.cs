using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string RMessage { get; set; }
        public int Rating { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public Beer Beer { get; set; }
        public int BeerId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<RateReview> RateReviews { get; set; }
    }
}
