using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.BeerServiceTests
{
    [TestClass]
    public class DeleteBeer_Should
    {
        [TestMethod]
        public void DeleteBeer_Success()
        {
            //Arange
            using (var assertContext = Utils.GetContextWithData(nameof(DeleteBeer_Success)))
            {
                var sut = new BeerService(assertContext);
                var nrOfBeersBeforeDelete = sut.GetAllBeers().Count();
                //Act
                sut.DeleteBeer(1);
                var nrOfBeersAfterDelete = sut.GetAllBeers().Count();
                //Assert
                Assert.AreNotEqual(nrOfBeersBeforeDelete, nrOfBeersAfterDelete);
            }
        }

        [TestMethod]
        public void DeleteBeer_IdNotFound_ThrowException()
        {
            //Arange
            using (var assertContext = Utils.GetContextWithData(nameof(DeleteBeer_IdNotFound_ThrowException)))
            {
                var sut = new BeerService(assertContext);
                var id = 999;
                //Act and Assert
                Assert.ThrowsException<ArgumentNullException>(() => sut.DeleteBeer(id));
            }
        }
    }
}
