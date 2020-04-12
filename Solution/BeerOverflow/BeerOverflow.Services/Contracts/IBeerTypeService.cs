using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerTypeService
    {
        BeerTypeDTO GetBeerType(int id);
        IEnumerable<BeerTypeDTO> GetAllBeerTypes();
        BeerTypeDTO CreateBeerType(BeerTypeDTO beerTypeDTO);
        BeerTypeDTO UpdateBeerType(int id, string type, string description);
        bool DeleteBeerType(int id);
    }
}
