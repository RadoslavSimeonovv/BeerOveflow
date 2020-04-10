using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class UserBeersConfig : IEntityTypeConfiguration<UserBeers>
    {
        public void Configure(EntityTypeBuilder<UserBeers> builder)
        {
            builder.HasKey(b => new { b.UserId, b.BeerId });
        }
    }
 
}
