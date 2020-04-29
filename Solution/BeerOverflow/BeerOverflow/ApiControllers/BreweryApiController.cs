using System;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Web.Models;
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var breweryDTO = await this.breweryService.GetBreweryByIdAsync(id);

                var model = new BreweryViewModel(breweryDTO.Id, breweryDTO.Name,
                    breweryDTO.Description, breweryDTO.CountryId, breweryDTO.Country);

                return Ok(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var breweries = await this.breweryService.GetAllBreweriesAsync();
            var breweriesVM = breweries.Select(b => new BreweryViewModel(b.Id, b.Name, b.Description, b.CountryId, b.Country))
                .ToList();

            return Ok(breweriesVM);
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] BreweryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var breweryDTO = new BreweryDTO(model.Id, model.Name, model.Description, model.CountryId);


            var newBrewery = this.breweryService.CreateBreweryAsync(breweryDTO);

            return Created("Post", newBrewery);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BreweryViewModel model)
        {
            if (id == 0 || model == null)
            {
                return BadRequest();
            }
            var brewery = this.breweryService.UpdateBreweryAsync(id, model.Name, model.Description, model.CountryId);

            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var brewery = this.breweryService.DeleteBreweryAsync(id);

            return Ok();
        }
    }
}