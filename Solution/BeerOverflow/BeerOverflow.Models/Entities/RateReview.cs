using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class RateReview
    {
        public int Id { get; set; }
        public int LikeReview { get; set; }
        public string Message { get; set; }
        public bool IsInapropriate { get; set; } = false;
        public DateTime? DeletedOn { get; set; }

        public Review Review { get; set; }
        public int ReviewId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }


    }
}
