using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/breweries")]
    [ApiController]
    public class BreweryApiController : ControllerBase
    {
        private readonly IBreweryService breweryService;
        public BreweryApiController(IBreweryService breweryService)
        {
            this.breweryService = breweryService ?? throw new ArgumentNullException(nameof(breweryService));
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var breweryDTO = this.breweryService.GetBreweryById(id);

                var model = new BreweryViewModel
                {
                    Id = breweryDTO.Id,
                    Name = breweryDTO.Name,
                    Description = breweryDTO.Description,
                    CountryId = breweryDTO.CountryId,
                    Country = breweryDTO.Country
                };

                return Ok(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var breweries = this.breweryService.GetAllBreweries()
                .Select(b => new BreweryViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    CountryId = b.CountryId,
                    Country = b.Country

                }).ToList();

            return Ok(breweries);
        }


        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] BreweryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var breweryDTO = new BreweryDTO
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CountryId = model.CountryId,
            };

            var newBrewery = this.breweryService.CreateBrewery(breweryDTO);

            return Created("Post", newBrewery);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] BreweryViewModel model)
        {
            if (id == 0 || model == null)
            {
                return BadRequest();
            }

            var brewery = this.breweryService.UpdateBrewery(id, model.Name);

            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var country = this.breweryService.DeleteBrewery(id);

            return Ok();
        }
    }
}