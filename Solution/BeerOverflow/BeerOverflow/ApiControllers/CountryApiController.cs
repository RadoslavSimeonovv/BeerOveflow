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
    [Route("api/countries")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly ICountryService countryService;
        public CountryApiController(ICountryService countryService)
        {
            this.countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var countryDTO = this.countryService.GetCountryById(id);

                var model = new CountryViewModel(countryDTO.Id, countryDTO.Name);
    
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
            var countries = this.countryService.GetAllCountries()
                .Select(x => new CountryViewModel(x.Id, x.Name));

            return Ok(countries);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] CountryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var countryDTO = new CountryDTO(model.Id, model.Name);

            var newCountry = this.countryService.CreateCountry(countryDTO);

            return Created("Post", newCountry);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] CountryViewModel model)
        {
            if (id == 0 || model == null)
            {
                return BadRequest();
            }

            var country = this.countryService.UpdateCountry(id, model.Name);

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

            var country = this.countryService.DeleteCountry(id);

            return Ok();
        }
    }


}
