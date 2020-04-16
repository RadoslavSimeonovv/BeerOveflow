using System;
using System.Linq;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/beers")]
    [ApiController]
    public class BeerApiController : ControllerBase
    {
        private readonly IBeerService beerService;
        public BeerApiController(IBeerService beerService)
        {
            this.beerService = beerService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var models = beerService.GetAllBeers()
                .Select(b => new BeerViewModel
                {
                    Id = b.Id,
                    BeerName = b.BeerName,
                    AlcByVol = b.AlcByVol,
                    Description = b.Description,
                    //DateUnlisted = b.DateUnlisted,
                    Country = b.Country,
                    CountryId = b.CountryId,
                    BeerType = b.BeerType,
                    BeerTypeId = b.BeerTypeId,
                    Brewery = b.Brewery,
                    BreweryId = b.BreweryId,
                }).ToList();
            return Ok(models);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var beerDTO = beerService.GetBeer(id);
                var model = new BeerViewModel
                {
                    Id = beerDTO.Id,
                    BeerName = beerDTO.BeerName,
                    AlcByVol = beerDTO.AlcByVol,
                    Description = beerDTO.Description,
                    //DateUnlisted = beerDTO.DateUnlisted,
                    Country = beerDTO.Country,
                    CountryId = beerDTO.CountryId,
                    BeerType = beerDTO.BeerType,
                    BeerTypeId = beerDTO.BeerTypeId,
                    Brewery = beerDTO.Brewery,
                    BreweryId = beerDTO.BreweryId,
                };
                return Ok(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] BeerViewModel model)
        {
            try
            {
                var beerDto = new BeerDTO
                {
                    BeerName = model.BeerName,
                    AlcByVol = (double)model.AlcByVol,
                    Description = model.Description,
                    //DateUnlisted = model.DateUnlisted,
                    //Country = model.Country,
                    CountryId = model.CountryId,
                    //BeerType = model.BeerType,
                    BeerTypeId = model.BeerTypeId,
                    //Brewery = model.Brewery,
                    BreweryId = model.BreweryId,
                };
                var beer = beerService.CreateBeer(beerDto);
                return Created("Post", beer);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] BeerViewModel model)
        {
            var beerName = model.BeerName;
            var alkByVol = model.AlcByVol;
            var descr = model.Description;
            int countryId = model.CountryId;
            var beerTypeId = model.BeerTypeId;
            var breweryId = model.BreweryId;
            beerService.UpdateBeer(id, beerName, alkByVol, descr, countryId, beerTypeId, breweryId);
            return Ok();
            //UpdateBeer(int id, string beerName, double? abv, string description, string country, string beerType, string brewery)
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                beerService.DeleteBeer(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("filter")]
        public IActionResult Get(string country = null, string type = null, string orderby = null)
        {


                var beers = this.beerService.FilterBeers(country,type,orderby)
                 .Select(b => new BeerViewModel
                 {
                     Id = b.Id,
                     BeerName = b.BeerName,
                     AlcByVol = b.AlcByVol,
                     Description = b.Description,
                     //DateUnlisted = b.DateUnlisted,
                     Country = b.Country,
                     CountryId = b.CountryId,
                     BeerType = b.BeerType,
                     BeerTypeId = b.BeerTypeId,
                     Brewery = b.Brewery,
                     BreweryId = b.BreweryId,

                 }).ToList();

                return Ok(beers);
        }
    }
}