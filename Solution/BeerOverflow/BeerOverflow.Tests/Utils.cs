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
                }
            };

            var options = GetOptions(testName);
            var BfContext = new BeerOverflowContext(options);
            BfContext.Beers.AddRange(beers);
            BfContext.SaveChanges();

            return BfContext;
        }
    }
}
