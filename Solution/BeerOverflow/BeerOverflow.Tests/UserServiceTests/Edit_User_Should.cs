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
    public class Edit_User_Should
    {
        [TestMethod]
        public void Return_Correct_Edited_User()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Edited_User));

            var user = new User
            {
                Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                UserName = "Boyanski",
                FirstName = "Boyan",
                LastName = "Vuchev",
                Email = "bvuchev@abv.bg",
                CreatedOn = DateTime.UtcNow

            };

            var mockArtistMapper = new Mock<IDateTimeProvider>();

            var username = "BoYanski";
            var newEmail = "bvuchev@gmail.com";
            var guid = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.SaveChanges();

            }
            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext, mockArtistMapper.Object);
                var result = sut.UpdateUser(user.Id, username, user.FirstName, user.LastName, newEmail);

                Assert.AreEqual(user.Id, result.Id);
                Assert.AreEqual(username, result.Username);
                Assert.AreEqual(newEmail, result.Email);
            }
        }


        [TestMethod]
        public void Throw_When_UserNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_UserNotFound));

            var mockArtistMapper = new Mock<IDateTimeProvider>();

            var user = new User
            {
                Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                UserName = "Boyanski",
                FirstName = "Boyan",
                LastName = "Vuchev",
                Email = "bvuchev@abv.bg",
                CreatedOn = DateTime.UtcNow

            };

            var guid = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");

            using (var assertContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(assertContext, mockArtistMapper.Object);

                Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateUser(guid, 
                    user.UserName, user.FirstName, user.LastName, user.Email));
            }
        }
    }
}
