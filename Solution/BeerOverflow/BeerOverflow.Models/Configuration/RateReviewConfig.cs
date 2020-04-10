using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class RateReviewConfig : IEntityTypeConfiguration<RateReview>
    {
        public void Configure(EntityTypeBuilder<RateReview> builder)
        {
            builder.HasKey(rr => rr.Id);
            builder.Property(rr => rr.LikeReview).IsRequired();
            builder.HasOne(rr => rr.User).WithMany(rr => rr.RateReviews).OnDelete(DeleteBehavior.Restrict);
 
        }
    }
   
}
