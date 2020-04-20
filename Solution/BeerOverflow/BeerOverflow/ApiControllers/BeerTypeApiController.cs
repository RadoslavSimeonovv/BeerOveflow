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
        public IActionResult Get()
        {
            var models = beerTypeServices.GetAllBeerTypes()
                .Select(bt => new BeerTypeViewModel
                {
                    Id = bt.Id,
                    Type = bt.Type,
                    Description = bt.Description,
                }).ToList();
            return Ok(models);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var beerTypeDTO = beerTypeServices.GetBeerType(id);
                var model = new BeerTypeViewModel
                {
                    Id = beerTypeDTO.Id,
                    Type = beerTypeDTO.Type,
                    Description = beerTypeDTO.Description,
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
        public IActionResult Post([FromBody] BeerTypeViewModel model)
        {
            try
            {
                var beerTypeDto = new BeerTypeDTO
                {
                    Type = model.Type,
                    Description = model.Description,
                };
                var beerType = beerTypeServices.CreateBeerType(beerTypeDto);
                return Created("Post", beerType);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] BeerTypeViewModel model)
        {
            var type = model.Type;
            var descr = model.Description;
            beerTypeServices.UpdateBeerType(id, type, descr);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                beerTypeServices.DeleteBeerType(id);
                return Ok(); //???
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}