using BeerOverflow.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Seeder
{
    public static class Seeder
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
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

            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin role",
                NormalizedName = "Sysadmin",
            });


            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 2,
                Name = "User",
                Description = "User role",
                NormalizedName = "Sysuser",
            });


            var hasher = new PasswordHasher<User>();
          

            User admin = new User
            {
                Id = 1,
                UserName = "bvuchev@abv.bg",
                NormalizedUserName = "BVUCHEV@ABV.BG",
                FirstName = "Boyan",
                LastName = "Vuchev",
                Email = "bvuchev@abv.bg",
                NormalizedEmail = "BVUCHEV@ABV.BG",
                LockoutEnabled = true,
                SecurityStamp = "DC6E275DD1E24957A7781D42BB68293B",
                CreatedOn = DateTime.UtcNow
            };


            admin.PasswordHash = hasher.HashPassword(admin, "123456");

            modelBuilder.Entity<User>().HasData(admin);

            User member1 = new User
            {
                Id = 2,
                UserName = "rsimeonov@abv.bg",
                NormalizedUserName = "RSIMEONOV@ABV.BG",
                FirstName = "Radoslav",
                LastName = "Simeonov",
                Email = "RSIMEONOV@aABV.BG",
                NormalizedEmail = "RSIMEONOV@ABV.BG",
                LockoutEnabled = true,
                SecurityStamp = "HNWQ7GQFUMWKGOAWSJNC5XV2VFYQRWHC",
                CreatedOn = DateTime.UtcNow
            };

            member1.PasswordHash = hasher.HashPassword(member1, "654321");

            modelBuilder.Entity<User>().HasData(member1);


            User member2 = new User
            {
                Id = 3,
                UserName = "ivan@abv.bg",
                NormalizedUserName = "IVAN@ABV.BG",
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "IVAN@ABV.BG",
                NormalizedEmail = "IVAN@ABV.BG",
                SecurityStamp = "CYHXVA33BAZ6B5DDG6AKUABAP3K7ONVY",
                LockoutEnabled = true,
               
                CreatedOn = DateTime.UtcNow
            };

            member2.PasswordHash = hasher.HashPassword(member2, "654321");

            modelBuilder.Entity<User>().HasData(member2);

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
           new IdentityUserRole<int>
           {
              RoleId = 1,
              UserId = 1
           });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
          new IdentityUserRole<int>
          {
              RoleId = 2,
              UserId = 2
          });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
          new IdentityUserRole<int>
          {
              RoleId = 2,
              UserId = 3
          });


            modelBuilder.Entity<UserBeers>().HasData(
            new UserBeers
            {
                UserId = 1,
                BeerId = 2
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
              UserId = 2,
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
             UserId = 2 ,
             BeerId = 2,
             DrankOn = DateTime.UtcNow
         });

            modelBuilder.Entity<UserBeers>().HasData(
            new UserBeers
            {
                UserId = 1,
                BeerId = 4,
                DrankOn = DateTime.UtcNow
            });

            modelBuilder.Entity<UserBeers>().HasData(
          new UserBeers
          {
              UserId = 2,
              BeerId = 5,
              DrankOn = DateTime.UtcNow
          });

            modelBuilder.Entity<UserBeers>().HasData(
         new UserBeers
         {
             UserId = 3,
             BeerId = 6,
         });

            modelBuilder.Entity<UserBeers>().HasData(
           new UserBeers
           {
               UserId = 2,
               BeerId = 9,
               DrankOn = DateTime.UtcNow
           });


                modelBuilder.Entity<UserBeers>().HasData(
          new UserBeers
          {
              UserId = 1,
              BeerId = 9,
              DrankOn = DateTime.UtcNow
          });




            modelBuilder.Entity<Review>().HasData(
           new Review
           {
               Id = 1,
               RMessage = "Cool beer!",
               Rating = 5,
               UserId = 1,
               BeerId = 9,
               ReviewedOn = DateTime.UtcNow

           });

            modelBuilder.Entity<Review>().HasData(
          new Review
          {
              Id = 2,
              RMessage = "Very fresh, would buy again!",
              Rating = 4,
              UserId = 2,
              BeerId = 9,
              ReviewedOn = DateTime.UtcNow

          });

            modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = 3,
                RMessage = "I don't recommend it!",
                Rating = 1,
                UserId = 3,
                BeerId = 6,
                ReviewedOn = DateTime.UtcNow

            });

            modelBuilder.Entity<Review>().HasData(
         new Review
         {
             Id = 4,
             RMessage = "Top class!",
             Rating = 5,
             UserId = 1,
             BeerId = 4,
             ReviewedOn = DateTime.UtcNow

         });


            modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = 5,
                RMessage = "Not great, not terrible.",
                Rating = 3,
                UserId = 2,
                BeerId = 2,
                ReviewedOn = DateTime.UtcNow

            });

            modelBuilder.Entity<Review>().HasData(
           new Review
           {
               Id = 6,
               RMessage = "Not my taste.",
               Rating = 2,
               UserId = 1,
               BeerId = 3,
               ReviewedOn = DateTime.UtcNow

           });

            modelBuilder.Entity<Review>().HasData(
           new Review
           {
               Id = 7,
               RMessage = "Rip off!",
               Rating = 1,
               UserId = 3,
               BeerId = 7,
               ReviewedOn = DateTime.UtcNow

           });

        
        }
    }
}
