using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Tests.UserServiceTests
{
    [TestClass]
    public class Get_All_Users_Should_
    {
        [TestMethod]
        public void Return_Correct_Users()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Users));

            var user = new User
            {
                Id = 1,
                Username = "Boyanski",
                FirstName = "Boyan",
                LastName = "Vuchev",
                Email = "bvuchev@abv.bg",
                CreatedOn = DateTime.UtcNow

            };

            var user2 = new User
            {
                Id = 2,
                Username = "RSimeonov",
                FirstName = "Radoslav",
                LastName = "Simeonov",
                Email = "rsimeonovv@abv.bg",
                CreatedOn = DateTime.UtcNow
            };

            var mockArtistMapper = new Mock<IDateTimeProvider>();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Users.Add(user2);
                arrangeContext.SaveChanges();

            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext, mockArtistMapper.Object);
                var result = sut.GetAllUsers().First();

                Assert.AreEqual(user.Id, result.Id);
                Assert.AreEqual(user.Username, result.Username);
                Assert.AreEqual(user.FirstName, result.FirstName);
                Assert.AreEqual(user.LastName, result.LastName);
                Assert.AreEqual(user.Email, result.Email);

            }
        }
    }
}
