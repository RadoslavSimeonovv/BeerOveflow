using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.BeerServiceTests
{
    [TestClass]
    public class GetAllBeers_Should
    {
        [TestMethod]
        public void GetAllBeers_Correct()
        {
            //Arange
            using (var assertContext = Utils.GetContextWithData(nameof(GetAllBeers_Correct)))
            {
                var sut = new BeerService(assertContext);
                var nrOfBeers = assertContext.Beers.Count();
                //Act and Assert
                var result = sut.GetAllBeers().Count();
                Assert.AreEqual(nrOfBeers, result);
            }
        }
    }
}
