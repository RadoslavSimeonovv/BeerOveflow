using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.BeerTypeTests
{
    [TestClass]
    public class Delete_Type_Should
    {
        [TestMethod]
        public void ReturnTrue_When_TypeIsDeleted()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_When_TypeIsDeleted));
            var beerType = new BeerType
            {
                Id = 1,
                Description = "Type of beer conditioned at low temperatures.",
                Type = "Lager",
            };
            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType);
                arrangeContext.SaveChanges();

            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypesService(assertContext);
                var result = sut.DeleteBeerType(1);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void Throw_When_TypeNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_TypeNotFound));

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypesService(assertContext);

                Assert.ThrowsException<ArgumentNullException>(() => sut.GetBeerType(1));
            }
        }


    }
}



    
    

