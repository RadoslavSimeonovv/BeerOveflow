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
    public class Delete_Brewery_Should
    {
        [TestMethod]
        public void ReturnTrue_When_TypeIsDeleted()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_When_TypeIsDeleted));

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
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(assertContext);
                var result = sut.DeleteBrewery(1);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void Throw_When_BreweryNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_BreweryNotFound));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(assertContext);

                Assert.ThrowsException<ArgumentNullException>(() => sut.DeleteBrewery(1));
            }
        }
    }
}
