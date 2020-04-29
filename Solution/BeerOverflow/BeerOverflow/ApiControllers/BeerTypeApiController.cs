using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/beertypes")]
    [ApiController]
    public class BeerTypeApiController : ControllerBase
    {
        private readonly IBeerTypeService beerTypeServices;
        public BeerTypeApiController(IBeerTypeService beerTypeServices)
        {
            this.beerTypeServices = beerTypeServices;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetBeerTypes()
        {
            var beerTypes = await this.beerTypeServices.GetAllBeerTypesAsync();
            var beerTypesVM = beerTypes
                .Select(bt => new BeerTypeViewModel(bt.Id, bt.Type, bt.Description))
                .ToList();

            return Ok(beerTypesVM);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var beerTypeDTO = await this.beerTypeServices.GetBeerTypeAsync(id);
                var model = new BeerTypeViewModel(beerTypeDTO.Id, beerTypeDTO.Type, beerTypeDTO.Description);
                return Ok(model);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateBeerType([FromBody] BeerTypeViewModel model)
        {
            try
            {
                var beerTypeDto = new BeerTypeDTO(model.Type, model.Description);
                var beerType = await this.beerTypeServices.CreateBeerTypeAsync(beerTypeDto);
                return Created("Post", beerType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBeerType(int id, [FromBody] BeerTypeViewModel model)
        {
            var type = model.Type;
            var descr = model.Description;
            await this.beerTypeServices.UpdateBeerTypeAsync(id, type, descr);
            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await this.beerTypeServices.DeleteBeerTypeAsync(id);
                return Ok(); 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}