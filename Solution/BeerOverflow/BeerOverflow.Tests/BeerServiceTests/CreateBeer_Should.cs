using BeerOverflow.Data;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeerOverflow.Tests.BeerServiceTests
{
    [TestClass]
    public class CreateBeer_Should
    {
        [TestMethod]
        public void CreateBeer_Success()
        {
            //Arrange
            var beerDTO = new BeerDTO
            {
                BeerName = "Boliarka",
                BeerTypeId = 1,
                BreweryId = 1,
                AlcByVol = (double)3.2,
                Description = "Stava",
            };
            var options = Utils.GetOptions(nameof(CreateBeer_Success));
            //Act & Assert
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerService(assertContext);
                var result = sut.CreateBeer(beerDTO);
                Assert.AreEqual(beerDTO.BeerName, result.BeerName);
                Assert.AreEqual(beerDTO.BeerTypeId, result.BeerTypeId);
                Assert.AreEqual(beerDTO.BreweryId, result.BreweryId);
                Assert.AreEqual(beerDTO.AlcByVol, result.AlcByVol);
                Assert.AreEqual(beerDTO.Description, result.Description);
            }
        }
    }
}