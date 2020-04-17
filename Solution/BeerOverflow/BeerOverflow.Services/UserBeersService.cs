using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class UserBeersService : IUserBeersService
    {
        private readonly BeerOverflowContext _beerOverflowContext;

        public UserBeersService(BeerOverflowContext beerOverflowContext)
        {
            this._beerOverflowContext = beerOverflowContext;
        }

        public UserBeersDTO AddBeerToDrankList(string userName, string beerName)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.Username == userName);
            
            if(user == null)
            {
                throw new ArgumentNullException("User does not exist!");
            }
            var beer = _beerOverflowContext.Beers.FirstOrDefault(b => b.BeerName == beerName);

            if (beer == null)
            {
                throw new ArgumentNullException("Beer does not exist!");
            }
            var userBeer = _beerOverflowContext.UserBeers
                .Where(ub => ub.UserId == user.Id)
                .FirstOrDefault(ub => ub.BeerId == beer.Id);

            if(userBeer == null)
            {
                var newUserBeer = new UserBeers
                {
                    UserId = user.Id,
                    BeerId = beer.Id,
                    DrankOn = DateTime.UtcNow           
                };
                _beerOverflowContext.UserBeers.Add(newUserBeer);
                _beerOverflowContext.SaveChanges();
            }
            else
            {
                if(userBeer.DrankOn == null)
                {
                    userBeer.DrankOn = DateTime.UtcNow;
                    _beerOverflowContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Already drank this beer!");
                }
            }

            var userBeerDTO = new UserBeersDTO
            {
                UserId = user.Id,
                BeerId = beer.Id,
                User = user.Username,
                Beer = beer.BeerName,
                DrankOn = userBeer.DrankOn
            };

            return userBeerDTO;

        }

        public UserBeersDTO AddBeerToWishList(string userName, string beerName)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.Username == userName);
            
            if(user == null)
            {
                throw new ArgumentNullException("User is null!");
            }
            var beer = _beerOverflowContext.Beers.FirstOrDefault(b => b.BeerName == beerName);

            if (beer == null)
            {
                throw new ArgumentNullException("Beer is null!");
            }
            var userBeer = new UserBeers
            {
               UserId = user.Id,
               BeerId = beer.Id
            };

            try
            {
                _beerOverflowContext.UserBeers.Add(userBeer);
                _beerOverflowContext.SaveChanges();
            }
            catch(Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }

            var userBeerDTO = new UserBeersDTO
            {
                UserId = user.Id,
                BeerId = beer.Id,
                User = user.Username,
                Beer = beer.BeerName
            };

            return userBeerDTO;
        }

        public IEnumerable<UserBeersDTO> GetUserDrankList(string userName)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.Username == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User does not exist!");
            }

            var userBeers = _beerOverflowContext.UserBeers
               .Where(ub => ub.UserId == user.Id)
               .Where(ub => ub.DrankOn != null)
               //.Include(u => u.User)
               //.Include(b => b.Beer)
               .Select(ub => new UserBeersDTO
               {
                   UserId = ub.UserId,
                   BeerId = ub.BeerId,
                   User = ub.User.Username,
                   Beer = ub.Beer.BeerName,
                   DrankOn = ub.DrankOn
               });

            return userBeers;
        }

        public IEnumerable<UserBeersDTO> GetUserWishList(string userName)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.Username == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User does not exist!");
            }

            var userBeers = _beerOverflowContext.UserBeers
                .Where(ub => ub.UserId == user.Id)
                .Where(ub => ub.DrankOn == null)
                .Include(u => u.User)
                .Include(b => b.Beer)
                .Select(ub => new UserBeersDTO
                {
                    UserId = ub.UserId,
                    BeerId = ub.BeerId,
                    User = ub.User.Username,
                    Beer = ub.Beer.BeerName,
                });

            return userBeers;
        }



    }
}
