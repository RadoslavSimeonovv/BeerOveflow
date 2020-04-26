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
    public class Edit_Brewery_Should
    {
        [TestMethod]
        public void Return_Correct_Edited_Brewery()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Edited_Brewery));

            var brewery = new Brewery
            {
                Id = 1,
                Name = "Diamond Knot Brewery",
                Description = "America",
                CountryId = 1
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Breweries.Add(brewery);
                arrangeContext.SaveChanges();
            }

            var newName = "DKB";
            var newDescr = "USA";
            var newCountryId = 2;

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(assertContext);

                var result = sut.UpdateBrewery(brewery.Id, newName, newDescr, newCountryId);

                Assert.AreEqual(brewery.Id, result.Id);
                Assert.AreEqual(newName, result.Name);
                Assert.AreEqual(newDescr, result.Description);
                Assert.AreEqual(newCountryId, result.CountryId);
            }
        }

        [TestMethod]
        public void Throw_When_BreweryNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_BreweryNotFound));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(assertContext);

                var newName = "DKB";
                var newDescr = "USA";
                var newCountryId = 2;
                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateBrewery(1, newName, newDescr, newCountryId));
            }
        }

    }
}
