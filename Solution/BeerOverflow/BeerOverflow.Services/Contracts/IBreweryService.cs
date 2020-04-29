using BeerOverflow.Services.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IBreweryService
    {
        BreweryDTO GetBreweryById(int id);
        IEnumerable<BreweryDTO> GetAllBreweries();
        BreweryDTO CreateBrewery(BreweryDTO breweryDTO);
        BreweryDTO UpdateBrewery(int id, string newName, string newDescrip, int newCountryId);
        bool DeleteBrewery(int id);

        Task<BreweryDTO> GetBreweryByIdAsync(int id);
        Task<IEnumerable<BreweryDTO>> GetAllBreweriesAsync();
        Task<BreweryDTO> CreateBreweryAsync(BreweryDTO breweryDTO);
        Task<BreweryDTO> UpdateBreweryAsync(int id, string newName, string newDescrip, int newCountryId);
        Task<bool> DeleteBreweryAsync(int id);

    }
}
