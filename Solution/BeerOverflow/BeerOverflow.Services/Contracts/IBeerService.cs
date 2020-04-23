using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IBeerService
    {
        BeerDTO GetBeer(int id);
        IEnumerable<BeerDTO> GetAllBeers();
        IEnumerable<BeerDTO> FilterBeers(string country, string type, string orderby);
        BeerDTO UpdateBeer(int id, string beerName, double? abv, string description, int countryId, int beerTypeId, int breweryId);
        BeerDTO CreateBeer(BeerDTO beerDTO);
        bool DeleteBeer(int id);

        IQueryable<BeerDTO> GetBeers(string sortOrder, string currentFilter, string searchString);
    }
}
