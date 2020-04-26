using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.CountryServiceTests
{
    [TestClass]
    public class CreateCountryShould
    {
        [TestMethod]
        public void CreateCountry_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateCountry_Correct));
            var country = new Country
            {
                Id = 11,
                Name = "Bulgaria"
            };
                
            //Act & Assert
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new CountryService(assertContext);
                var countryDTO = new CountryDTO(country.Id, country.Name);
                var result = sut.CreateCountry(countryDTO);

                Assert.AreEqual(country.Id, result.Id);
                Assert.AreEqual(country.Name, result.Name);
            }
        }
    }
}
