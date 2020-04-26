using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.BreweryServiceTests
{
    [TestClass]
    public class Create_Brewery_Should
    {
        [TestMethod]
        public void Create_Correct_Brewery()
        {
            var options = Utils.GetOptions(nameof(Create_Correct_Brewery));
            var brewery = new Brewery
            {
                Id = 1,
                Name = "Diamond Knot Brewery",
                Description = "America",
                CountryId = 1
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                var sut = new BreweryService(arrangeContext);
                var breweryDTO = new BreweryDTO(brewery.Id, brewery.Name, brewery.Description, brewery.CountryId);
                var result = sut.CreateBrewery(breweryDTO);

                Assert.AreEqual(brewery.Id, result.Id);
                Assert.AreEqual(brewery.Name, result.Name);
                Assert.AreEqual(brewery.Description, result.Description);
                Assert.AreEqual(brewery.CountryId, result.CountryId);
            }
        }
    }
}
