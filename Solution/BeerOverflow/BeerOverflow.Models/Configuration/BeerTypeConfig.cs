using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class BeerTypeConfig : IEntityTypeConfiguration<BeerType>
    {
        public void Configure(EntityTypeBuilder<BeerType> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Type).IsRequired();
            builder.Property(b => b.Description).IsRequired();

            //builder.HasOne(b => b.BeerType).WithMany(b => b.Beers).HasForeignKey(b => b.BeerTypesID);
        }
    }
 
}
