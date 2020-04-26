using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.BreweryServiceTests
{
    [TestClass]
    public class Get_All_Breweries_Should
    {
        [TestMethod]
        public void Return_Correct_Breweries()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Breweries));

            var country = new Country
            {
                Id = 1,
                Name = "America"
            };

            var brewery = new Brewery
            {
                Id = 1,
                Name = "Diamond Knot Brewery",
                Description = "America",
                CountryId = 1,
                Country = country
            };

            var brewery2 = new Brewery
            {
                Id = 2,
                Name = "Anheuser-Busch",
                Description = "American brewery",
                CountryId = 1,
                Country = country
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.Breweries.Add(brewery2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(assertContext);

                var result = sut.GetAllBreweries().First();

                Assert.AreEqual(brewery.Id, result.Id);
                Assert.AreEqual(brewery.Name, result.Name);
                Assert.AreEqual(brewery.Description, result.Description);
                Assert.AreEqual(brewery.CountryId, result.CountryId);
                Assert.AreEqual(brewery.Country.Name, result.Country);
            }
        }
    }
}
