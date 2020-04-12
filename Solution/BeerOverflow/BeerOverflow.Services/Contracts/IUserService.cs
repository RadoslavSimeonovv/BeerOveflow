using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IUserService
    {
        UserDTO GetUserById(int id);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO CreateUser(UserDTO userDTO);
        UserDTO UpdateUser(int id, string newName);
        bool DeleteUser(int id);

    }
}
