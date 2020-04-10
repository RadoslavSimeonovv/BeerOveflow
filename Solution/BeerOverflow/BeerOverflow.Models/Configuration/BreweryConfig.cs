using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class BreweryConfig : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Description).IsRequired();
        }
    }
}
