using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IUserService
    {
        UserDTO GetUserById(Guid id);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO CreateUser(UserDTO userDTO);
        UserDTO UpdateUser(Guid id, string newUsername, string newFirstName, string newLastName, string newEmail);
        bool DeleteUser(Guid id);

    }
}
