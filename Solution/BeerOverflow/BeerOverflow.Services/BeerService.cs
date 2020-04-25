﻿using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


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
                .Where(b => b.DateUnlisted == null)
                .FirstOrDefault(b => b.Id == id);
            if (beer == null)
            {
                throw new ArgumentNullException();
            }
            var beerDto = new BeerDTO(beer.Id, beer.BeerName, beer.BeerTypeId, beer.BeerType.Type, beer.BreweryId, beer.Brewery.Name, beer.AlcByVol, beer.Description);

            return beerDto;
        }
        public IEnumerable<BeerDTO> GetAllBeers()
        {
            var beersDTO = _beerOverflowContext.Beers
                .Include(b => b.BeerType)
                .Include(b => b.Brewery)
                .Where(b => b.DateUnlisted == null)
                .Select(b => new BeerDTO(b.Id, b.BeerName, b.BeerTypeId, b.BeerType.Type, b.BreweryId, b.Brewery.Name, b.AlcByVol, b.Description)).ToList();

            return beersDTO;
        }

        public IQueryable<BeerDTO> GetBeers(string sortOrder, string currentFilter, string searchString)
        {
            var beersQry = (IQueryable<Beer>)_beerOverflowContext.Beers
                .Include(b => b.BeerType)
                .Include(b => b.Brewery);

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

            var beerDTOs = beersQry.Select(b => new BeerDTO(b.Id, b.BeerName,b.BeerTypeId, b.BeerType.Type, b.BreweryId, b.Brewery.Name, b.AlcByVol, b.Description));

            return beerDTOs;
        }
        public BeerDTO CreateBeer(BeerDTO beerDTO)
        {
            try
            {
                var beer = new Beer(beerDTO.BeerName, beerDTO.BeerTypeId, beerDTO.BreweryId, beerDTO.AlcByVol, beerDTO.Description);
                _beerOverflowContext.Beers.Add(beer);
                _beerOverflowContext.SaveChanges();
                return beerDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BeerDTO UpdateBeer(int id, string beerName, double? abv, string description, int beerTypeId, int breweryId)
        {

            var beer = _beerOverflowContext.Beers
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

            if (breweryId != 0)
            {
                var _brewery = _beerOverflowContext.Breweries.Find(breweryId);
                if (_brewery == null)
                {
                    throw new ArgumentException("Provided brewery is not within the list of breweries");
                }
                beer.BreweryId = _brewery.Id;
            }

            if (beerTypeId != 0)
            {
                var _beerType = _beerOverflowContext.BeerTypes.Find(beerTypeId);
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
        public IEnumerable<BeerDTO> FilterBeers(string type, string orderby)
        {
            var qryBeers = (IQueryable<Beer>)_beerOverflowContext.Beers;

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
                    .Select(b => new BeerDTO(b.Id, b.BeerName, b.BeerTypeId, b.BeerType.Type, b.BreweryId, b.Brewery.Name, b.AlcByVol, b.Description)).ToList();

            return beersDTO;
        }

        public IEnumerable<BeerDTO> FilterBeersNew()
        {
            throw new NotImplementedException();
        }


    }
}
