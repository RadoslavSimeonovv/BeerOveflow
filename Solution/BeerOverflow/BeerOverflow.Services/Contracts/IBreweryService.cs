using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IBreweryService
    {
        BreweryDTO GetBreweryById(int id);
        IEnumerable<BreweryDTO> GetAllBreweries();
        BreweryDTO CreateBrewery(BreweryDTO breweryDTO);
        BreweryDTO UpdateBrewery(int id, string newName);
        bool DeleteBrewery(int id);

    }
}
