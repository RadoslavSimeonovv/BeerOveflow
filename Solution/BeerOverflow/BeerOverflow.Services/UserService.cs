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
                UserName = userDTO.Username,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                CreatedOn = this.dateTimeProvider.GetDateTime()
            };

            _beerOverflowContext.Users.Add(user);
            _beerOverflowContext.SaveChanges();

            return userDTO;
        }

        public bool DeleteUser(Guid id)
        {
            var user = _beerOverflowContext.Users
            .FirstOrDefault(user => user.Id == id);

            if (user == null)
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
               .Select(u => new UserDTO(u.Id, u.UserName, u.FirstName,
               u.LastName, u.Email, u.CreatedOn));
            
            return users;
        }

        public UserDTO GetUserById(Guid id)
        {
            var user = _beerOverflowContext.Users.
                FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var userDTO = new UserDTO(user.Id, user.UserName, user.FirstName,
               user.LastName, user.Email, user.CreatedOn);
                    
            return userDTO;
        }

        public UserDTO UpdateUser(Guid id, string newUsername, string newFirstName, string newLastName, string newEmail )
        {
            var user = _beerOverflowContext.Users
                .FirstOrDefault(user => user.Id == id);

            if(user == null)
            {
                throw new ArgumentNullException();
            }

            user.UserName = newUsername;
            user.FirstName = newFirstName;
            user.LastName = newLastName;
            user.Email = newEmail;


            var userDTO = new UserDTO(user.Id, user.UserName, user.FirstName, user.LastName, user.Email);

            _beerOverflowContext.Users.Update(user);
            _beerOverflowContext.SaveChanges();

            return userDTO;
        }
    }
}
