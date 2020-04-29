using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerTypeService
    {
        BeerTypeDTO GetBeerType(int id);
        Task<BeerTypeDTO> GetBeerTypeAsync(int id);
        IEnumerable<BeerTypeDTO> GetAllBeerTypes();
        Task<IEnumerable<BeerTypeDTO>> GetAllBeerTypesAsync();
        BeerTypeDTO CreateBeerType(BeerTypeDTO beerTypeDTO);
        Task<BeerTypeDTO> CreateBeerTypeAsync(BeerTypeDTO beerTypeDTO);
        BeerTypeDTO UpdateBeerType(int id, string type, string description);
        Task<BeerTypeDTO> UpdateBeerTypeAsync(int id, string type, string description);
        bool DeleteBeerType(int id);
        Task<bool> DeleteBeerTypeAsync(int id);
    }
}
