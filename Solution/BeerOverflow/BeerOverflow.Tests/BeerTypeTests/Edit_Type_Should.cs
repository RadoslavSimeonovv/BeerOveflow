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
    public class Edit_Type_Should
    {
        [TestMethod]
        public void Return_Correct_Edited_Type()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Edited_Type));

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

            var newType = "Lageerr";
            var newDescr = "Updated";

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypesService(arrangeContext);

                var result = sut.UpdateBeerType(beerType.Id, newType, newDescr);

                Assert.AreEqual(beerType.Id, result.Id);
                Assert.AreEqual(newType, result.Type);
                Assert.AreEqual(newDescr, result.Description);
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
