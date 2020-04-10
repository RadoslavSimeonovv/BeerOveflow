using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RMessage).IsRequired();
            builder.Property(r => r.Rating).IsRequired();
            builder.HasIndex(r => new { r.UserId, r.BeerId }).IsUnique(true);
        }

    }
}
