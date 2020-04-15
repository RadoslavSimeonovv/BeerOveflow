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
    public class BeerService : IBeerService
    {
        private readonly BeerOverflowContext _beerOverflowContext;
        public BeerService(BeerOverflowContext beerOverflowContext)
        {
            this._beerOverflowContext = beerOverflowContext;
        }
        public BeerDTO GetBeer(int id)
        {
            var beer = _beerOverflowContext.Beers
                .Include(b => b.BeerType)
                .Include(b => b.Brewery)
                .Include(b => b.Country)
                .Where(b => b.DateUnlisted == null)
                .FirstOrDefault(b => b.Id == id);
            if (beer == null)
            {
                throw new ArgumentNullException();
            }
            var beerDto = new BeerDTO
            {
                Id = beer.Id,
                BeerName = beer.BeerName,
                BeerTypeId = beer.BeerTypeId,
                BeerType = beer.BeerType.Type,
                BreweryId = beer.BreweryId,
                Brewery = beer.Brewery.Name,
                CountryId = beer.CountryId,
                Country = beer.Country.Name,
                AlcByVol = beer.AlcByVol,
                Description = beer.Description,
            };
            return beerDto;
        }
        public IEnumerable<BeerDTO> GetAllBeers()
        {
            var beersDTO = _beerOverflowContext.Beers
                .Include(b => b.BeerType)
                .Include(b => b.Brewery)
                .Include(b => b.Country)
                .Select(b => new BeerDTO
                {
                    Id = b.Id,
                    BeerName = b.BeerName,
                    BeerTypeId = b.BeerTypeId,
                    BeerType = b.BeerType.Type,
                    BreweryId = b.BreweryId,
                    Brewery = b.Brewery.Name,
                    CountryId = b.CountryId,
                    Country = b.Country.Name,
                    AlcByVol = b.AlcByVol,
                    Description = b.Description,
                }).ToList();
            return beersDTO;
        }
        public BeerDTO CreateBeer(BeerDTO beerDTO)
        {
            try
            {
                var beer = new Beer
                {
                    BeerName = beerDTO.BeerName,
                    BeerTypeId = beerDTO.BeerTypeId,
                    BreweryId = beerDTO.BreweryId,
                    CountryId = beerDTO.CountryId,
                    AlcByVol = beerDTO.AlcByVol,
                    Description = beerDTO.Description,
                };
                _beerOverflowContext.Beers.Add(beer);
                //_beerOverflowContext.Update(beer);
                _beerOverflowContext.SaveChanges();
                return beerDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BeerDTO UpdateBeer(int id, string beerName, double? abv, string description, int countryId, int beerTypeId, int breweryId)
        {

            var beer = _beerOverflowContext.Beers
                //.Include(b => b.BeerType)
                //.Include(b => b.Brewery)
                //.Include(b => b.Country)
                .Where(b => b.DateUnlisted == null)
                .FirstOrDefault(b => b.Id == id);
            if (beer == null)
            {
                throw new ArgumentNullException();
            }

            if (beerName != null)
                beer.BeerName = beerName;

            if (abv != null)
                beer.AlcByVol = (double)abv;

            if (description != null)
                beer.Description = description;

            if (countryId != 0)
            {
                var ctry = _beerOverflowContext.Countries.Find(countryId);
                if (ctry == null)
                {
                    throw new ArgumentException("Provided country is not within the list of countries");
                }
                beer.CountryId = ctry.Id;
            }

            if (breweryId != 0)
            {
                var _brewery = _beerOverflowContext.Breweries.Find(breweryId);
                //.FirstOrDefault(br => br.Name == brewery);
                if (_brewery == null)
                {
                    throw new ArgumentException("Provided brewery is not within the list of breweries");
                }
                beer.BreweryId = _brewery.Id;
            }

            if (beerTypeId != 0)
            {
                var _beerType = _beerOverflowContext.BeerTypes.Find(beerTypeId);
                //.FirstOrDefault(br => br.Type == beerType);
                if (_beerType == null)
                {
                    throw new ArgumentException("Provided beer type is not within the list of beer types");
                }
                beer.BeerTypeId = _beerType.Id;
            }
            _beerOverflowContext.Update(beer);
            _beerOverflowContext.SaveChanges();

            return GetBeer(id);
        }

        public bool DeleteBeer(int id)
        {
            var beer = _beerOverflowContext.Beers.Find(id);
            if (id == 0 || beer == null)
            {
                throw new ArgumentNullException();
            }
            beer.DateUnlisted = DateTime.UtcNow;
            //_beerOverflowContext.Beers.Remove(beer);
            _beerOverflowContext.Update(beer);
            _beerOverflowContext.SaveChanges();

            return true;

        }
        public IEnumerable<BeerDTO> FilterBeers(string filterString)
        {

            var searchFilter = _beerOverflowContext.Beers.FirstOrDefault(b => b.BeerType.Type == filterString);

            if (searchFilter != null)
            {
                var beersDTO = _beerOverflowContext.Beers
                  .Where(b => b.BeerType.Type == filterString)
                  .Include(b => b.BeerType)
                  .Include(b => b.Brewery)
                  .Include(b => b.Country)
                  .Select(b => new BeerDTO
                  {
                      Id = b.Id,
                      BeerName = b.BeerName,
                      BeerTypeId = b.BeerTypeId,
                      BeerType = b.BeerType.Type,
                      BreweryId = b.BreweryId,
                      Brewery = b.Brewery.Name,
                      CountryId = b.CountryId,
                      Country = b.Country.Name,
                      AlcByVol = b.AlcByVol,
                      Description = b.Description,
                  }).ToList();
                return beersDTO;
            }
            else
            {
                searchFilter = _beerOverflowContext.Beers.FirstOrDefault(b => b.Country.Name == filterString);
                if (searchFilter != null)
                {
                    var beersDTO = _beerOverflowContext.Beers
                 .Where(b => b.Country.Name == filterString)
                 .Include(b => b.BeerType)
                 .Include(b => b.Brewery)
                 .Include(b => b.Country)
                 .Select(b => new BeerDTO
                 {
                     Id = b.Id,
                     BeerName = b.BeerName,
                     BeerTypeId = b.BeerTypeId,
                     BeerType = b.BeerType.Type,
                     BreweryId = b.BreweryId,
                     Brewery = b.Brewery.Name,
                     CountryId = b.CountryId,
                     Country = b.Country.Name,
                     AlcByVol = b.AlcByVol,
                     Description = b.Description,
                 }).ToList();
                    return beersDTO;
                }
            }
            return null;
        }


    }
}
