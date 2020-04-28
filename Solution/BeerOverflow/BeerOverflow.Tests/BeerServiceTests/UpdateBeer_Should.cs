using BeerOverflow.Services;
using BeerOverflow.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.BeerServiceTests
{
    [TestClass]
    public class UpdateBeer_Should
    {
        [TestMethod]
        public void UpdateBeer_BeerName_Success()
        {
            //Arange, Act & Assert
            using (var assertContext = Utils.GetContextWithData(nameof(UpdateBeer_BeerName_Success)))
            {
                var id = 1;
                var sut = new BeerService(assertContext);
                var oldName = sut.GetBeer(id).BeerName;
                var nameToUpdate = "Gayda";
                BeerDTO result = sut.UpdateBeer(id, nameToUpdate, null, null, 1, 1);
                Assert.AreNotEqual(oldName, nameToUpdate);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
        "Beer is null!")]
        public void UpdateBeer_BeerNotFound_ThrowException()
        {
            //Arange, Act & Assert
            using (var assertContext = Utils.GetContextWithData(nameof(UpdateBeer_BeerNotFound_ThrowException)))
            {
                var sut = new BeerService(assertContext);
                int id = 999;
                sut.UpdateBeer(id, null, null, null, 1,1);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Provided brewery is not within the list of breweries")]
        public void UpdateBeer_BreweryNotFound_ThrowException()
        {
            //Arange, Act & Assert
            using (var assertContext = Utils.GetContextWithData(nameof(UpdateBeer_BreweryNotFound_ThrowException)))
            {
                var sut = new BeerService(assertContext);
                int breweryId = 999;
                sut.UpdateBeer(1, null, null, null, 1, breweryId);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
         "Provided beer type is not within the list of beer types")]
        public void UpdateBeer_BeerTypeNotFound_ThrowException()
        {
            //Arange, Act & Assert
            using (var assertContext = Utils.GetContextWithData(nameof(UpdateBeer_BeerTypeNotFound_ThrowException)))
            {
                var sut = new BeerService(assertContext);
                int beerTypeId = 999;
                sut.UpdateBeer(1, null, null, null, beerTypeId, 1);
            }
        }
    }
}
