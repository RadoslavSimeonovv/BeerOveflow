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

            this.SeedDatabase(modelBuilder);
        }



        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "United States",
                });
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 2,
                    Name = "Belgium",
                });
            modelBuilder.Entity<Country>().HasData(
             new Country
             {
                 Id = 3,
                 Name = "Germany",
             });

            modelBuilder.Entity<Country>().HasData(
             new Country
             {
                 Id = 4,
                 Name = "United Kingdom",
             });

            modelBuilder.Entity<Country>().HasData(
             new Country
             {
                 Id = 5,
                 Name = "Canada",
             });

            modelBuilder.Entity<Country>().HasData(
             new Country
             {
                 Id = 6,
                 Name = "Netherlands",
             });
            modelBuilder.Entity<Country>().HasData(
           new Country
           {
               Id = 7,
               Name = "Mexico",
           });
            modelBuilder.Entity<Country>().HasData(
           new Country
           {
               Id = 8,
               Name = "Switzerland",
           });
            modelBuilder.Entity<Country>().HasData(
           new Country
           {
               Id = 9,
               Name = "China",
           });
            modelBuilder.Entity<Country>().HasData(
           new Country
           {
               Id = 10,
               Name = "Norway",
           });


            modelBuilder.Entity<BeerType>().HasData(
           new BeerType
           {
               Id = 1,
               Description = "Style of beer that was developed in London in the early eighteenth century.",
               Type = "Porter",
           });

            modelBuilder.Entity<BeerType>().HasData(
           new BeerType
           {
               Id = 2,
               Description = "Type of beer conditioned at low temperatures.",
               Type = "Lager",
           });

            modelBuilder.Entity<BeerType>().HasData(
           new BeerType
           {
               Id = 3,
               Description = "Type of beer brewed using a warm fermentation method",
               Type = "Ale",
           });

            modelBuilder.Entity<BeerType>().HasData(
           new BeerType
           {
               Id = 4,
               Description = "Dark, top-fermented beer with a number of variations, including dry stout, Baltic porter, milk stout, and imperial stout.",
               Type = "Stout",
           });




            modelBuilder.Entity<Brewery>().HasData(
            new Brewery
            {
                Id = 1,
                Name = "Diamond Knot Brewery",
                Description = "America",
                CountryId = 1
            });

            modelBuilder.Entity<Brewery>().HasData(
           new Brewery
           {
               Id = 2,
               Name = "Anheuser-Busch",
               Description = "American brewery",
               CountryId = 1
           });

            modelBuilder.Entity<Brewery>().HasData(
           new Brewery
           {
               Id = 3,
               Name = "Greene King",
               Description = "English brewery",
               CountryId = 4
           });

            modelBuilder.Entity<Brewery>().HasData(
           new Brewery
           {
               Id = 4,
               Name = "Heineken International",
               Description = "Dutch brewery",
               CountryId = 3
           });

            modelBuilder.Entity<Brewery>().HasData(
            new Brewery
            {
                Id = 5,
                Name = "Brouwerij van Hoegaarden",
                Description = "Belge brewery",
                CountryId = 2
            });

            modelBuilder.Entity<Brewery>().HasData(
            new Brewery
            {
                Id = 6,
                Name = "Grupo Modelo",
                Description = "Mexican brewery",
                CountryId = 7
            });

            modelBuilder.Entity<Brewery>().HasData(
         new Brewery
         {
             Id = 7,
             Name = "CR Snow",
             Description = "Chinese brewery",
             CountryId = 9
         });

            modelBuilder.Entity<Brewery>().HasData(
          new Brewery
          {
              Id = 8,
              Name = "Left Hand Brewing",
              Description = "American brewery",
              CountryId = 1
          });

            modelBuilder.Entity<Brewery>().HasData(
            new Brewery
            {
                Id = 9,
                Name = "Tsingtao Brewery",
                Description = "Chinese brewery",
                CountryId = 4
            });



            modelBuilder.Entity<Brewery>().HasData(
            new Brewery
            {
                Id = 10,
                Name = "Coors Brewing Company",
                Description = "American brewery",
                CountryId = 1
            });

            modelBuilder.Entity<Beer>().HasData(
          new Beer
          {
              Id = 1,
              BeerName = "Possession Porter",
              Description = "American beer",
              AlcByVol = 5.6,
              BeerTypeId = 1,
              BreweryId = 1
          });

            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 2,
                BeerName = "Wexford Irish Cream Ale",
                Description = "English beer",
                AlcByVol = 5.0,
                BeerTypeId = 3,
                BreweryId = 3

            });

            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 3,
                BeerName = "Hoegaarden",
                Description = "Belge beer",
                AlcByVol = 4.9,
                BeerTypeId = 3,
                BreweryId = 5
            });

            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 4,
                BeerName = "Heineken",
                Description = "Dutch beer",
                AlcByVol = 5.0,
                BeerTypeId = 3,
                BreweryId = 4
            });

            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 5,
                BeerName = "Corona Extra",
                Description = "Mexican-Belge beer",
                AlcByVol = 4.5,
                BeerTypeId = 2,
                BreweryId = 6
            });

            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 6,
                BeerName = "Snow",
                Description = "Chinese beer",
                AlcByVol = 4.0,
                BeerTypeId = 2,
                BreweryId = 7
            });

            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 7,
                BeerName = "Budweiser",
                Description = "American beer",
                AlcByVol = 5.0,
                BeerTypeId = 2,
                BreweryId = 1
            });

            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 8,
                BeerName = "Left Hand Milk Stout",
                Description = "English beer",
                AlcByVol = 5.0,
                BeerTypeId = 4,
                BreweryId = 8
            });

            modelBuilder.Entity<Beer>().HasData(
        new Beer
        {
            Id = 9,
            BeerName = "Tsingtao",
            Description = "Chinese beer",
            AlcByVol = 5.0,
            BeerTypeId = 3,
            BreweryId = 3
        });


            modelBuilder.Entity<Beer>().HasData(
            new Beer
            {
                Id = 10,
                BeerName = "Coors Light",
                Description = "English beer",
                AlcByVol = 4.2,
                BeerTypeId = 2,
                BreweryId = 10

            });


            modelBuilder.Entity<User>().HasData(
          new User
          {
              Id = 1,
              Username = "Boyanski",
              FirstName = "Boyan",
              LastName = "Vuchev",
              Email = "bvuchev@abv.bg",
              CreatedOn = DateTime.UtcNow

          });

            modelBuilder.Entity<User>().HasData(
          new User
          {
              Id = 2,
              Username = "RSimeonov",
              FirstName = "Radoslav",
              LastName = "Simeonov",
              Email = "rsimeonovv@abv.bg",
              CreatedOn = DateTime.UtcNow
          });


            modelBuilder.Entity<User>().HasData(
          new User
          {
              Id = 3,
              Username = "PeturPetrof",
              FirstName = "Petur",
              LastName = "Petrov",
              Email = "peshop@gmail.com",
              CreatedOn = DateTime.UtcNow
          });

            modelBuilder.Entity<User>().HasData(
          new User
          {
              Id = 4,
              Username = "VankataV",
              FirstName = "Ivan",
              LastName = "Stoyanov",
              Email = "vankatas@gmail.com",
              CreatedOn = DateTime.UtcNow
          });


            modelBuilder.Entity<User>().HasData(
          new User
          {
              Id = 5,
              Username = "GeritoIv",
              FirstName = "Gergana",
              LastName = "Ivanova",
              Email = "geriflow@gmail.com",
              CreatedOn = DateTime.UtcNow

          });

            modelBuilder.Entity<User>().HasData(
          new User
          {
              Id = 6,
              Username = "MimiG",
              FirstName = "Mariya",
              LastName = "Angelova",
              Email = "mimiang@gmail.com",
              CreatedOn = DateTime.UtcNow

          });




            modelBuilder.Entity<Review>().HasData(
           new Review
           {
               Id = 1,
               RMessage = "Cool beer!",
               Rating = 5,
               UserId  = 4,
               BeerId = 1,
               ReviewedOn = DateTime.UtcNow

           });

            modelBuilder.Entity<Review>().HasData(
          new Review
          {
              Id = 2,
              RMessage = "Very fresh, would buy again!",
              Rating = 4,
              UserId = 3,
              BeerId = 7,
              ReviewedOn = DateTime.UtcNow

          });

            modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = 3,
                RMessage = "I don't recommend it!",
                Rating = 1,
                UserId = 6,
                BeerId = 8,
                ReviewedOn = DateTime.UtcNow

            });

            modelBuilder.Entity<Review>().HasData(
         new Review
         {
             Id = 4,
             RMessage = "Top class!",
             Rating = 5,
             UserId = 5,
             BeerId = 8,
             ReviewedOn = DateTime.UtcNow

         });

            modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = 5,
                RMessage = "Not great, not terrible.",
                Rating = 3,
                UserId = 1,
                BeerId = 2,
                ReviewedOn = DateTime.UtcNow

            });

            modelBuilder.Entity<Review>().HasData(
           new Review
           {
               Id = 6,
               RMessage = "Not my taste.",
               Rating = 2,
               UserId = 4,
               BeerId = 5,
               ReviewedOn = DateTime.UtcNow

           });

            modelBuilder.Entity<Review>().HasData(
           new Review
           {
               Id = 7,
               RMessage = "Rip off!",
               Rating = 1,
               UserId = 4,
               BeerId = 2,
               ReviewedOn = DateTime.UtcNow

           });

            modelBuilder.Entity<Review>().HasData(
             new Review
             {
                 Id = 8,
                 RMessage = "I already bought another 10 of those!",
                 Rating = 5,
                 UserId = 6,
                 BeerId = 4,
                 ReviewedOn = DateTime.UtcNow

             });

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 9,
                    RMessage = "Decent taste and price!",
                    Rating = 4,
                    UserId = 1,
                    BeerId = 3,
                    ReviewedOn = DateTime.UtcNow

                });


            modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = 10,
                RMessage = "My friend lied to me, its not that good.",
                Rating = 3,
                UserId = 3,
                BeerId = 10,
                ReviewedOn = DateTime.UtcNow

            });

            modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = 11,
                RMessage = "Excellent!",
                Rating = 5,
                UserId = 2,
                BeerId = 7,
                ReviewedOn = DateTime.UtcNow

            });




          modelBuilder.Entity<UserBeers>().HasData(
          new UserBeers
          {
              UserId = 2,
              BeerId = 7,
              DrankOn = DateTime.UtcNow
          });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 3,
             BeerId = 7,
             DrankOn = DateTime.UtcNow
         });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 3,
             BeerId = 5,
         });

            modelBuilder.Entity<UserBeers>().HasData(
          new UserBeers
          {
              UserId = 3,
              BeerId = 10,
          });


            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 1,
             BeerId = 3,
             DrankOn = DateTime.UtcNow
         });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 4,
             BeerId = 2,
             DrankOn = DateTime.UtcNow
         });

            modelBuilder.Entity<UserBeers>().HasData(
            new UserBeers
            {
                UserId = 4,
                BeerId = 1,
                DrankOn = DateTime.UtcNow
            });

            modelBuilder.Entity<UserBeers>().HasData(
          new UserBeers
          {
              UserId = 4,
              BeerId = 5,
              DrankOn = DateTime.UtcNow
          });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 6,
             BeerId = 1,
         });

            modelBuilder.Entity<UserBeers>().HasData(
           new UserBeers
           {
               UserId = 6,
               BeerId = 3,
           });

            modelBuilder.Entity<UserBeers>().HasData(
        new UserBeers
        {
            UserId = 6,
            BeerId = 4,
        });
            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 2,
             BeerId = 1,
         });

            modelBuilder.Entity<UserBeers>().HasData(
       new UserBeers
       {
           UserId = 2,
           BeerId = 4,
       });
            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 3,
             BeerId = 3,
         });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 4,
             BeerId = 7,
         });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 5,
             BeerId = 8,
             DrankOn = DateTime.UtcNow
         });

            modelBuilder.Entity<UserBeers>().HasData(
          new UserBeers
          {
              UserId = 6,
              BeerId = 8,
              DrankOn = DateTime.UtcNow
          });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 1,
             BeerId = 2,
             DrankOn = DateTime.UtcNow
         });




        }
    }
}
