using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            var user = new User
            {
                Id = userDTO.Id,
                UserName = userDTO.Username,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                CreatedOn = DateTime.UtcNow
            };

            _beerOverflowContext.Users.Add(user);
            await _beerOverflowContext.SaveChangesAsync();

            return userDTO;
        }

        public bool DeleteUser(int id)
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

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _beerOverflowContext.Users
            .FirstOrDefaultAsync(user => user.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _beerOverflowContext.Users.Remove(user);
            await _beerOverflowContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _beerOverflowContext.Users
               .Select(u => new UserDTO(u.Id, u.UserName, u.FirstName,
               u.LastName, u.Email, u.CreatedOn));

            return users;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _beerOverflowContext.Users
               .Select(u => new UserDTO(u.Id, u.UserName, u.FirstName,
               u.LastName, u.Email, u.CreatedOn)).ToListAsync();

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

            var userDTO = new UserDTO(user.Id, user.UserName, user.FirstName,
               user.LastName, user.Email, user.CreatedOn);

            return userDTO;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _beerOverflowContext.Users.
                FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var userDTO = new UserDTO(user.Id, user.UserName, user.FirstName,
               user.LastName, user.Email, user.CreatedOn);

            return userDTO;
        }

        public UserDTO UpdateUser(int id, string newUsername, string newFirstName, string newLastName, string newEmail)
        {
            var user = _beerOverflowContext.Users
                .FirstOrDefault(user => user.Id == id);

            if (user == null)
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

        public async Task<UserDTO> UpdateUserAsync(int id, string newUsername, string newFirstName, string newLastName, string newEmail)
        {
            var user = await _beerOverflowContext.Users
                .FirstOrDefaultAsync(user => user.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.UserName = newUsername;
            user.FirstName = newFirstName;
            user.LastName = newLastName;
            user.Email = newEmail;


            var userDTO = new UserDTO(user.Id, user.UserName, user.FirstName, user.LastName, user.Email);

            _beerOverflowContext.Users.Update(user);
            await _beerOverflowContext.SaveChangesAsync();

            return userDTO;
        }

        public async Task<bool> BanUser(int id)
        {
            var user = await _beerOverflowContext.Users
                    .FirstOrDefaultAsync(user => user.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.isBanned = true;

            _beerOverflowContext.Users.Update(user);
            await _beerOverflowContext.SaveChangesAsync();

            return true;
        }

    }
}
