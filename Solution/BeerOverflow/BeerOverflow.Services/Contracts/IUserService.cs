using BeerOverflow.Services.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IUserService
    {
        UserDTO GetUserById(int id);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO CreateUser(UserDTO userDTO);
        UserDTO UpdateUser(int id, string newUsername, string newFirstName, string newLastName, string newEmail);
        bool DeleteUser(int id);

        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> CreateUserAsync(UserDTO userDTO);
        Task<UserDTO> UpdateUserAsync(int id, string newUsername, string newFirstName, string newLastName, string newEmail);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> BanUser(int id);

    }
}