﻿using BeerOverflow.Data;
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
    public class Get_User_Should
    {
        [TestMethod]
        public void Return_Correct_User()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_User));

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
                var result = sut.GetUserById(1);

                Assert.AreEqual(user.Id, result.Id);
                Assert.AreEqual(user.UserName, result.Username);
                Assert.AreEqual(user.FirstName, result.FirstName);
                Assert.AreEqual(user.LastName, result.LastName);
                Assert.AreEqual(user.Email, result.Email);

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

                Assert.ThrowsException<ArgumentNullException>(() => sut.GetUserById(1));
                   
            }
        }
    }
}
