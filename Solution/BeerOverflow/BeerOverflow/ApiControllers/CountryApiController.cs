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

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetCountry(int id)
        //{
        //    try
        //    {
        //        var countryDTO = this.countryService.GetCountryById(id);

        //        var model = new CountryViewModel(countryDTO.Id, countryDTO.Name);
    
        //        return Ok(model);
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCountryAsync(int id)
        {
            try
            {
                var countryDTO = await this.countryService.GetCountryByIdAsync(id);

                var model = new CountryViewModel(countryDTO.Id, countryDTO.Name);

                return Ok(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //[Route("")]
        //public IActionResult GetAll()
        //{
        //    var countries = this.countryService.GetAllCountries()
        //        .Select(x => new CountryViewModel(x.Id, x.Name));

        //    return Ok(countries);
        //}


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var countries = await this.countryService.GetAllCountriesAsync();
            var countriesVM = countries.Select(x => new CountryViewModel(x.Id, x.Name)).ToList();

            return Ok(countries);
        }

        //[HttpPost]
        //[Route("")]
        //public IActionResult Create([FromBody] CountryViewModel model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }

        //    var countryDTO = new CountryDTO(model.Id, model.Name);

        //    var newCountry = this.countryService.CreateCountry(countryDTO);

        //    return Created("Post", newCountry);
        //}


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync ([FromBody] CountryViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var countryDTO = new CountryDTO(model.Id, model.Name);

            var newCountry = await this.countryService.CreateCountryAsync(countryDTO);

            return Created("Post", newCountry);
        }


        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult UpdateCountry(int id, [FromBody] CountryViewModel model)
        //{
        //    if (id == 0 || model == null)
        //    {
        //        return BadRequest();
        //    }

        //    var country = this.countryService.UpdateCountry(id, model.Name);

        //    return Ok();
        //}

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCountryAsync(int id, [FromBody] CountryViewModel model)
        {
            if (id == 0 || model == null)
            {
                return BadRequest();
            }

            var country = await this.countryService.UpdateCountryAsync(id, model.Name);

            return Ok();
        }


        //[HttpDelete]
        //[Route("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return BadRequest();
        //    }

        //    var country = this.countryService.DeleteCountry(id);

        //    return Ok();
        //}

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var country = await this.countryService.DeleteCountryAsync(id);

            return Ok();
        }
    }


}
