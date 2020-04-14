using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Services.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class UserService : IUserService
    {
        private readonly BeerOverflowContext _beerOverflowContext;
        private readonly IDateTimeProvider dateTimeProvider;

        public UserService(BeerOverflowContext beerOverflowContext, IDateTimeProvider dateTimeProvider)
        {
            this._beerOverflowContext = beerOverflowContext;
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        public UserDTO CreateUser(UserDTO userDTO)
        {
            var user = new User
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                CreatedOn = this.dateTimeProvider.GetDateTime()
            };

            _beerOverflowContext.Users.Add(user);
            _beerOverflowContext.SaveChanges();

            return userDTO;
        }

        public bool DeleteUser(int id)
        {
            var user = _beerOverflowContext.Users
            .FirstOrDefault(user => user.Id == id);

            if (id == 0 || user == null)
            {
                throw new ArgumentNullException();
            }

            _beerOverflowContext.Users.Remove(user);
            _beerOverflowContext.SaveChanges();

            return true;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _beerOverflowContext.Users
               .Select(u => new UserDTO
               {
                   Id = u.Id,
                   Username = u.Username,
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Email = u.Email,
                   CreatedOn = u.CreatedOn
                   

               });

            return users;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _beerOverflowContext.Users.
                FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedOn = user.CreatedOn
            };

            return userDTO;
        }

        public UserDTO UpdateUser(int id, string newName)
        {
            var user = _beerOverflowContext.Users
                .FirstOrDefault(user => user.Id == id);

            user.Username = newName;

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
            };

            _beerOverflowContext.Users.Update(user);
            _beerOverflowContext.SaveChanges();

            return userDTO;
        }
    }
}
