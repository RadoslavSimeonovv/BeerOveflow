using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService
    {
        BeerDTO GetBeer(int id);
        Task<BeerDTO> GetBeerAsync(int id);
        IEnumerable<BeerDTO> GetAllBeers();
        Task <IEnumerable<BeerDTO>> GetAllBeersAsync();
        IEnumerable<BeerDTO> FilterBeers(string type, string orderby);
        Task <IEnumerable<BeerDTO>> FilterBeersAsync(string type, string orderby);
        BeerDTO UpdateBeer(int id, string beerName, double? abv, string description, int beerTypeId, int breweryId);
        Task <BeerDTO> UpdateBeerAsync(int id, string beerName, double? abv, string description, int beerTypeId, int breweryId);
        BeerDTO CreateBeer(BeerDTO beerDTO);
        Task<BeerDTO> CreateBeerAsync(BeerDTO beerDTO);
        bool DeleteBeer(int id);
        Task <bool> DeleteBeerAsync(int id);

        IQueryable<BeerDTO> GetBeers(string sortOrder, string currentFilter, string searchString);
        Task<IQueryable<BeerDTO>> GetBeersAsync(string sortOrder, string currentFilter, string searchString);
    }
}
