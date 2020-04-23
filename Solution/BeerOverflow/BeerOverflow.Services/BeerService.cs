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
                .Where(b => b.DateUnlisted == null)
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

        public IQueryable<BeerDTO> GetBeers(string sortOrder, string currentFilter, string searchString)
        {
            var beersQry = (IQueryable<Beer>)_beerOverflowContext.Beers
                .Include(b => b.BeerType)
                .Include(b => b.Brewery)
                .Include(b => b.Country);

            if (!String.IsNullOrEmpty(searchString))
            {
                beersQry = beersQry.Where(b => b.BeerName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    beersQry = beersQry.OrderByDescending(b => b.BeerName);
                    break;
                case "abv":
                    beersQry = beersQry.OrderBy(b => b.AlcByVol);
                    break;
                case "abv_desc":
                    beersQry = beersQry.OrderByDescending(b => b.AlcByVol);
                    break;
                case "beertype":
                    beersQry = beersQry.OrderBy(b => b.BeerType);
                    break;
                case "beertype_desc":
                    beersQry = beersQry.OrderByDescending(b => b.BeerType);
                    break;
                case "country":
                    beersQry = beersQry.OrderBy(b => b.Country);
                    break;
                case "country_desc":
                    beersQry = beersQry.OrderByDescending(b => b.Country);
                    break;
                case "brewery":
                    beersQry = beersQry.OrderBy(b => b.Brewery);
                    break;
                case "brewery_desc":
                    beersQry = beersQry.OrderByDescending(b => b.Brewery);
                    break;
                default:
                    beersQry = beersQry.OrderBy(b => b.BeerName);
                    break;
            }

            var beerDTOs = beersQry.Select(b => new BeerDTO
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
            });

            return beerDTOs;
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
            _beerOverflowContext.SaveChanges();

            return true;

        }
        public IEnumerable<BeerDTO> FilterBeers(string country, string type, string orderby)
        {
            var qryBeers = (IQueryable<Beer>)_beerOverflowContext.Beers;
            if (country != null)
            {
                var ctry = _beerOverflowContext.Countries.FirstOrDefault(c => c.Name == country);
                if (ctry != null)
                {
                    qryBeers = qryBeers.Where(b => b.CountryId == ctry.Id);
                }
            }

            if (type != null)
            {
                var _type = _beerOverflowContext.BeerTypes.FirstOrDefault(t => t.Type == type);
                if (_type != null)
                {
                    qryBeers = qryBeers.Where(b => b.BeerTypeId == _type.Id);
                }
            }

            if (orderby != null)
            {
                var orderClauses = orderby.ToLower().Split(",");
                for (int i = 0; i < orderClauses.Length; i++)
                {
                    var orderPropArr = orderClauses[i].Split(" ");
                    var orderProp = orderPropArr[0].Trim();
                    switch (orderProp)
                    {
                        case "name":
                            if (!orderClauses[i].EndsWith(" desc"))
                                qryBeers = i == 0 ? qryBeers.OrderBy(b => b.BeerName)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.BeerName);
                            else
                            {
                                qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.BeerName)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.BeerName);
                            }
                            break;
                        case "abv":
                            if (!orderClauses[i].EndsWith(" desc"))
                                qryBeers = i == 0 ? qryBeers.OrderBy(b => b.AlcByVol)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.AlcByVol);
                            else
                            {
                                qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.AlcByVol)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.AlcByVol);
                            }
                            break;
                        case "county":
                            if (!orderClauses[i].EndsWith(" desc"))
                                qryBeers = i == 0 ? qryBeers.OrderBy(b => b.Country)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.Country);
                            else
                            {
                                qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.Country)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.Country);
                            }
                            break;
                        case "brewery":
                            if (!orderClauses[i].EndsWith(" desc"))
                                qryBeers = i == 0 ? qryBeers.OrderBy(b => b.Brewery)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenBy(b => b.Brewery);
                            else
                            {
                                qryBeers = i == 0 ? qryBeers.OrderByDescending(b => b.Brewery)
                                    : ((IOrderedQueryable<Beer>)qryBeers).ThenByDescending(b => b.Brewery);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            var beersDTO = qryBeers
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

        public IEnumerable<BeerDTO> FilterBeersNew()
        {
            throw new NotImplementedException();
        }


    }
}
