using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.UserServiceTests
{
    [TestClass]
    public class Delete_User_Should
    {
        [TestMethod]
        public void ReturnTrue_When_UserIsDeleted()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_When_UserIsDeleted));

            var user = new User
            {
                Id = 1,
                UserName = "Boyanski",
                FirstName = "Boyan",
                LastName = "Vuchev",
                Email = "bvuchev@abv.bg",
                CreatedOn = DateTime.UtcNow

            };

            var mockArtistMapper = new Mock<IDateTimeProvider>();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();

            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext, mockArtistMapper.Object);
                var result = sut.DeleteUser(1);

                Assert.IsTrue(result);
            }
        }


        [TestMethod]
        public void Throw_When_UserNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_UserNotFound));

            var mockArtistMapper = new Mock<IDateTimeProvider>();

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext, mockArtistMapper.Object);

                Assert.ThrowsException<ArgumentNullException>(() => sut.DeleteUser(1));
            }
        }
    }
}
