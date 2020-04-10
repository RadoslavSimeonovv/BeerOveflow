using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class UserRolesConfig : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.HasKey(b => new { b.UserId, b.RoleId });
           
       
        }
    }

}


