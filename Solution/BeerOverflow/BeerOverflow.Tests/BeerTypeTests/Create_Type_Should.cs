using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.BeerTypeTests
{
    [TestClass]
    public class Create_Type_Should
    {
        [TestMethod]
        public void Create_Correct_BeerType()
        {
            var options = Utils.GetOptions(nameof(Create_Correct_BeerType));
            var beerType = new BeerType
            {
                Id = 1,
                Description = "Type of beer conditioned at low temperatures.",
                Type = "Lager",
            };

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                var sut = new BeerTypesService(arrangeContext);
                var beerTypeDTO = new BeerTypeDTO(beerType.Id, beerType.Type, beerType.Description);
                var result = sut.CreateBeerType(beerTypeDTO);

                Assert.AreEqual(beerType.Id, result.Id);
                Assert.AreEqual(beerType.Type, result.Type);
                Assert.AreEqual(beerType.Description, result.Description);
            }
        }

        




    }
}
