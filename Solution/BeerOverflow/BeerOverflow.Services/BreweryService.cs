using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly BeerOverflowContext _beerOverflowContext;

        public BreweryService(BeerOverflowContext beerOverflowContext)
        {
            this._beerOverflowContext = beerOverflowContext;
        }


        public BreweryDTO CreateBrewery(BreweryDTO breweryDTO)
        {
            var brewery = new Brewery
            {
                Id = breweryDTO.Id,
                Name = breweryDTO.Name,
                Description = breweryDTO.Description,
                CountryId = breweryDTO.CountryId,
            };

            _beerOverflowContext.Breweries.Add(brewery);
            _beerOverflowContext.SaveChanges();

            return breweryDTO;
        }

        public bool DeleteBrewery(int id)
        {
            var brewery = _beerOverflowContext.Breweries
               .FirstOrDefault(brewery => brewery.Id == id);

            if (id == 0 || brewery == null)
            {
                throw new ArgumentNullException();
            }

            brewery.DeletedOn = DateTime.UtcNow;

            _beerOverflowContext.Breweries.Update(brewery);
            _beerOverflowContext.SaveChanges();

            return true;
        }

        public IEnumerable<BreweryDTO> GetAllBreweries()
        {
            var breweries = _beerOverflowContext.Breweries.
              Include(b => b.Country).
              Where(b => b.DeletedOn == null).
              Select(b => new BreweryDTO(b.Id, b.Name, 
              b.Description, b.CountryId, b.Country.Name))
              .ToList();

            return breweries;
        }

        public BreweryDTO GetBreweryById(int id)
        {
            var brewery = _beerOverflowContext.Breweries.
               Where(b => b.Id == id).
               Include(b => b.Country).
               FirstOrDefault();

            if (brewery == null)
            {
                throw new ArgumentNullException();
            }

            var breweryDTO = new BreweryDTO(brewery.Id, brewery.Name, 
                brewery.Description, brewery.CountryId, brewery.Country.Name);

            return breweryDTO;
        }

        public BreweryDTO UpdateBrewery(int id, string newName, string newDescrip, int newCountryId)
        {
            var brewery = _beerOverflowContext.Breweries
               .FirstOrDefault(brewery => brewery.Id == id);

            if(brewery == null)
            {
                throw new ArgumentNullException();
            }

            brewery.Name = newName;
            brewery.Description = newDescrip;
            brewery.CountryId = newCountryId;

            var breweryDTO = new BreweryDTO(brewery.Id, brewery.Name, 
                brewery.Description, brewery.CountryId);

            _beerOverflowContext.Breweries.Update(brewery);
            _beerOverflowContext.SaveChanges();

            return breweryDTO;
        }

    }
}
