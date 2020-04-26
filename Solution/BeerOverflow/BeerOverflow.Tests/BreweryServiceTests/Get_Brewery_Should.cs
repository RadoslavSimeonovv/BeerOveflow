using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.BreweryServiceTests
{
    [TestClass]
    public class Get_Brewery_Should
    {

        [TestMethod]
        public void Return_Correct_Brewery()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Brewery));

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

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(assertContext);

                var result = sut.GetBreweryById(1);

                Assert.AreEqual(brewery.Id, result.Id);
                Assert.AreEqual(brewery.Name, result.Name);
                Assert.AreEqual(brewery.Description, result.Description);
                Assert.AreEqual(brewery.CountryId, result.CountryId);
                Assert.AreEqual(brewery.Country.Name, result.Country);
            }
        }

        [TestMethod]
        public void Throw_When_BreweryNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_BreweryNotFound));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(assertContext);

                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBreweryById(1));
            }
        }
    }
}
