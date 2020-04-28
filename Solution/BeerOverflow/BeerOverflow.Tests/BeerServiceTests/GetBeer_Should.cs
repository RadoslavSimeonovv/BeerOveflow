using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BeerOverflow.Tests.BeerServiceTests
{
    [TestClass]
    public class GetBeer
    {
        [TestMethod]
        public void GetBeer_Correct()
        {
            //Arange
            using (var assertContext = Utils.GetContextWithData(nameof(GetBeer_Correct)))
            {
                var sut = new BeerService(assertContext);
                //Act and Assert
                int id = 1;
                var result = sut.GetBeer(id);
                Assert.AreEqual(id, result.Id);
            }
        }
        [TestMethod]
        public void GetBeer_MissingId_ThrowException()
        {
            //Arange
            using (var assertContext = Utils.GetContextWithData(nameof(GetBeer_MissingId_ThrowException)))
            {
                var sut = new BeerService(assertContext);
                //Act and Assert
                int id = 999;

                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBeer(id));
            }
        }
    }
}
