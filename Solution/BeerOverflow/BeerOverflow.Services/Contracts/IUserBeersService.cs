using BeerOverflow.Services.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IUserBeersService
    {
        UserBeersDTO AddBeerToWishList(string userName, string beerName);
        UserBeersDTO AddBeerToDrankList(string userName, string beerName);

        IEnumerable<UserBeersDTO> GetUserWishList(string userName);
        IEnumerable<UserBeersDTO> GetUserDrankList(string userName);

        Task<UserBeersDTO> AddBeerToWishListAsync(string userName, string beerName);
        Task<UserBeersDTO> AddBeerToDrankListAsync(string userName, string beerName);

        Task<IEnumerable<UserBeersDTO>> GetUserWishListAsync(string userName);
        Task<IEnumerable<UserBeersDTO>> GetUserDrankListAsync(string userName);

    }
}
