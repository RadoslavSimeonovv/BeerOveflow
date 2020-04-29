using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.UserName == userName);
            
            if(user == null)
            {
                throw new ArgumentNullException("User is null!");
            }
            var beer = _beerOverflowContext.Beers.FirstOrDefault(b => b.BeerName == beerName);

            if (beer == null)
            {
                throw new ArgumentNullException("Beer is null!");
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

            var userBeerDTO = new UserBeersDTO(user.UserName, user.Id, 
                beer.BeerName, beer.Id,  userBeer.DrankOn);

            return userBeerDTO;

        }

        public async Task<UserBeersDTO> AddBeerToDrankListAsync(string userName, string beerName)
        {
            var user = await _beerOverflowContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }
            var beer = await _beerOverflowContext.Beers.FirstOrDefaultAsync(b => b.BeerName == beerName);

            if (beer == null)
            {
                throw new ArgumentNullException("Beer is null!");
            }
            var userBeer = await _beerOverflowContext.UserBeers
                .Where(ub => ub.UserId == user.Id)
                .FirstOrDefaultAsync(ub => ub.BeerId == beer.Id);

            if (userBeer == null)
            {
                var newUserBeer = new UserBeers
                {
                    UserId = user.Id,
                    BeerId = beer.Id,
                    DrankOn = DateTime.UtcNow
                };
                _beerOverflowContext.UserBeers.Add(newUserBeer);
                await _beerOverflowContext.SaveChangesAsync();
            }
            else
            {
                if (userBeer.DrankOn == null)
                {
                    userBeer.DrankOn = DateTime.UtcNow;
                    await _beerOverflowContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Already drank this beer!");
                }
            }

            var userBeerDTO = new UserBeersDTO(user.UserName, user.Id,
                beer.BeerName, beer.Id, userBeer.DrankOn);

            return userBeerDTO;

        }

        public UserBeersDTO AddBeerToWishList(string userName, string beerName)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.UserName == userName);
            
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

            var userBeerDTO = new UserBeersDTO(user.UserName, user.Id, 
                beer.BeerName, beer.Id);
 
            return userBeerDTO;
        }

        public async Task<UserBeersDTO> AddBeerToWishListAsync(string userName, string beerName)
        {
            var user = await _beerOverflowContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }
            var beer = await _beerOverflowContext.Beers.FirstOrDefaultAsync(b => b.BeerName == beerName);

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
                await _beerOverflowContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }

            var userBeerDTO = new UserBeersDTO(user.UserName, user.Id,
                beer.BeerName, beer.Id);

            return userBeerDTO;
        }

        public IEnumerable<UserBeersDTO> GetUserDrankList(string userName)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User does not exist!");
            }

            var userBeers = _beerOverflowContext.UserBeers
               .Where(ub => ub.UserId == user.Id)
               .Where(ub => ub.DrankOn != null)
               .Select(ub => new UserBeersDTO(ub.User.UserName, ub.UserId, 
               ub.Beer.BeerName, ub.BeerId, ub.DrankOn));

            return userBeers;
        }

        public async Task<IEnumerable<UserBeersDTO>> GetUserDrankListAsync(string userName)
        {
            var user = await _beerOverflowContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User does not exist!");
            }

            var userBeers = await _beerOverflowContext.UserBeers
               .Where(ub => ub.UserId == user.Id)
               .Where(ub => ub.DrankOn != null)
               .Select(ub => new UserBeersDTO(ub.User.UserName, ub.UserId,
               ub.Beer.BeerName, ub.BeerId, ub.DrankOn)).ToListAsync(); //TODO Check

            return userBeers;
        }
        public IEnumerable<UserBeersDTO> GetUserWishList(string userName)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User does not exist!");
            }

            var userBeers = _beerOverflowContext.UserBeers
                .Where(ub => ub.UserId == user.Id)
                .Where(ub => ub.DrankOn == null)
                .Include(u => u.User)
                .Include(b => b.Beer)
                .Select(ub => new UserBeersDTO(ub.User.UserName, ub.UserId,
                ub.Beer.BeerName, ub.BeerId));

            return userBeers;
        }

        public async Task<IEnumerable<UserBeersDTO>> GetUserWishListAsync(string userName)
        {
            var user = await _beerOverflowContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User does not exist!");
            }

            var userBeers = await _beerOverflowContext.UserBeers
                .Where(ub => ub.UserId == user.Id)
                .Where(ub => ub.DrankOn == null)
                .Include(u => u.User)
                .Include(b => b.Beer)
                .Select(ub => new UserBeersDTO(ub.User.UserName, ub.UserId,
                ub.Beer.BeerName, ub.BeerId)).ToListAsync();

            return userBeers;
        }
    }
}
