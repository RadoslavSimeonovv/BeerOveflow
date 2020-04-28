using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Services.Providers;
using BeerOverflow.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Tests.UserServiceTests
{
    [TestClass]
    public class Create_User_Should
    {
        [TestMethod]
        public void Create_Correct_User()
        {
            var options = Utils.GetOptions(nameof(Create_Correct_User));

            var user = new User
            {
                Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                UserName = "Boyanski",
                FirstName = "Boyan",
                LastName = "Vuchev",
                Email = "bvuchev@abv.bg",
                CreatedOn = DateTime.UtcNow

            };

            //var guid = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");
            var mockArtistMapper = new Mock<IDateTimeProvider>();

            using (var arrangeContext = new BeerOverflowContext(options))
            {
                var sut = new UserService(arrangeContext, mockArtistMapper.Object);
                var userDTO = new UserDTO(user.Id, user.UserName, user.FirstName,
                    user.LastName, user.Email, user.CreatedOn);
                var result = sut.CreateUser(userDTO);

                Assert.AreEqual(user.Id, result.Id);
                Assert.AreEqual(user.UserName, result.Username);
                Assert.AreEqual(user.FirstName, result.FirstName);
                Assert.AreEqual(user.LastName, result.LastName);
                Assert.AreEqual(user.Email, result.Email);
                Assert.AreEqual(user.CreatedOn, result.CreatedOn);
            }
        }
    }
}
