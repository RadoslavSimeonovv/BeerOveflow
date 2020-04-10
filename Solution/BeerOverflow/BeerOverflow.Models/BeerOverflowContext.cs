using BeerOverflow.Data.Configuration;
using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data
{
    public class BeerOverflowContext : DbContext
    {
        public BeerOverflowContext(DbContextOptions<BeerOverflowContext> options)
            : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<BeerType> BeerTypes { get; set; }
        public DbSet<Brewery> Breweries { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<UserBeers> UserBeers { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<RateReview> RateReviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new BeerConfig());
            modelBuilder.ApplyConfiguration(new BeerTypeConfig());
            modelBuilder.ApplyConfiguration(new BreweryConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRolesConfig());
            modelBuilder.ApplyConfiguration(new UserBeersConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new RateReviewConfig());
        }

    }
}
