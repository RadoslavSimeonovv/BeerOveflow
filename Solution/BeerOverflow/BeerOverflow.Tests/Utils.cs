using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests
{
    public class Utils
    {
        public static DbContextOptions<BeerOverflowContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<BeerOverflowContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static BeerOverflowContext GetContextWithData(string testName)
        {
            var beers = new Beer[]
            {
                new Beer
                {
                    Id = 1,
                    BeerName = "Ledenika",
                    AlcByVol = 3.3,
                    Description = "Dobra bira",
                    BeerTypeId = 1,
                    BreweryId = 1,
                },
                new Beer
                {
                    Id = 2,
                    BeerName = "Heineken",
                    AlcByVol = 4.8,
                    Description = "Ne struva",
                    BeerTypeId = 2,
                    BreweryId = 2,
                }
            };

            var beerTypes = new BeerType[]
            {
                new BeerType
                {
                    Id = 1,
                    Type = "Lager",
                    Description = "Lager beers"
                },
                new BeerType
                {
                    Id = 2,
                    Type = "Porter",
                    Description = "Porter beers"
                }
            };


            var countries = new Country[]
            {
                new Country
                {
                    Id = 1,
                    Name = "Bulgaria",
                },
                new Country
                {
                    Id = 2,
                    Name = "Romania",
                }
            };


            var breweries = new Brewery[]
            {
                new Brewery
                {
                    Id = 1,
                    Name = "Morsko brewery",
                    Description = "Obichame moreto",
                    CountryId = 1
                },

                new Brewery
                {
                    Id = 2,
                    Name = "Rumansko brewery",
                    Description = "Top",
                    CountryId = 2
                },
            };

            var users = new User[]
            {
                new User
                {
                    Id = 1,
                    UserName = "Boyanski",
                    FirstName = "Boyan",
                    LastName = "Vuchev",
                    Email = "bvuchev@abv.bg",
                    CreatedOn = DateTime.UtcNow
                },

                new User
                {
                    Id = 2,
                    UserName = "RSimeonov",
                    FirstName = "Radoslav",
                    LastName = "Simeonov",
                    Email = "rsimeonovv@abv.bg",
                    CreatedOn = DateTime.UtcNow
                }
            };
               
            var options = GetOptions(testName);
            var BfContext = new BeerOverflowContext(options);

            BfContext.Beers.AddRange(beers);
            BfContext.Users.AddRange(users);
            BfContext.BeerTypes.AddRange(beerTypes);
            BfContext.Countries.AddRange(countries);
            BfContext.Breweries.AddRange(breweries);
            BfContext.SaveChanges();

            return BfContext;
        }
    }
}
