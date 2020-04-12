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

            _beerOverflowContext.Breweries.Remove(brewery);
            _beerOverflowContext.SaveChanges();

            return true;
        }

        public IEnumerable<BreweryDTO> GetAllBreweries()
        {
            var breweries = _beerOverflowContext.Breweries.
              Include(b => b.Country).
              Select(b => new BreweryDTO
              {
                  Id = b.Id,
                  Name = b.Name,
                  Description = b.Description,
                  CountryId = b.CountryId,
                  Country = b.Country.Name
              });

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

            var breweryDTO = new BreweryDTO
            {
                Id = brewery.Id,
                Name = brewery.Name,
                Description = brewery.Description,
                CountryId = brewery.CountryId,
                Country = brewery.Country.Name
            };

            return breweryDTO;
        }

        public BreweryDTO UpdateBrewery(int id, string newName)
        {
            var brewery = _beerOverflowContext.Breweries
               .FirstOrDefault(brewery => brewery.Id == id);

            brewery.Name = newName;

            var breweryDTO = new BreweryDTO
            {
                Id = brewery.Id,
                Name = brewery.Name,
            };

            _beerOverflowContext.Breweries.Update(brewery);
            _beerOverflowContext.SaveChanges();

            return breweryDTO;
        }

    }
}
