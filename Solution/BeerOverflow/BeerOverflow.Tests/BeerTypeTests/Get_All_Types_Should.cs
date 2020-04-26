using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.BeerTypeTests
{
    [TestClass]
    public class Get_All_Types_Should
    {
        [TestMethod]
        public void Return_Correct_Types()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Types));

            var beerType1 = new BeerType
            {
                Id = 1,
                Description = "Type of beer conditioned at low temperatures.",
                Type = "Lager",
            };

            var beerType2 = new BeerType
            {
                Id = 2,
                Description = "Type of beer brewed using a warm fermentation method",
                Type = "Ale",
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.BeerTypes.Add(beerType1);
                arrangeContext.BeerTypes.Add(beerType2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypesService(assertContext);

                var result = sut.GetAllBeerTypes().First();

                Assert.AreEqual(beerType1.Id, result.Id);
                Assert.AreEqual(beerType1.Type, result.Type);
                Assert.AreEqual(beerType1.Description, result.Description);
            }
        }


    }
}

