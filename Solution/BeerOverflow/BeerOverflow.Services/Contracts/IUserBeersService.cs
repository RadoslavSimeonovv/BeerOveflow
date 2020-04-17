using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IUserBeersService
    {
        UserBeersDTO AddBeerToWishList(string userName, string beerName);
        UserBeersDTO AddBeerToDrankList(string userName, string beerName);

        IEnumerable<UserBeersDTO> GetUserWishList(string userName);
        IEnumerable<UserBeersDTO> GetUserDrankList(string userName);

    }
}
