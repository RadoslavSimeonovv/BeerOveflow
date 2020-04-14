using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class BeerConfig : IEntityTypeConfiguration<Beer>
    {    
        public void Configure(EntityTypeBuilder<Beer> builder)
        {         
            builder.HasKey(b => b.Id);
            builder.Property(b => b.BeerName).IsRequired().HasMaxLength(25);
            builder.HasIndex(b => b.BeerName).IsUnique();
            builder.Property(b => b.AlcByVol).IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.HasOne(b => b.Country).WithMany(b => b.Beers).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
