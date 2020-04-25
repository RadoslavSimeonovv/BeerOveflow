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
        private readonly IReviewService reviewService;
        public BeerApiController(IBeerService beerService, IReviewService reviewService)
        {
            this.beerService = beerService;
            this.reviewService = reviewService;

        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllBeers()
        {
            var models = beerService.GetAllBeers()
                .Select(b => new BeerViewModel(b.Id, b.BeerName, b.AlcByVol, 
                b.Description, b.BeerType, b.BeerTypeId, 
                b.Brewery, b.BreweryId)).ToList();

            return Ok(models);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var beerDTO = beerService.GetBeer(id);
                var model = new BeerViewModel(beerDTO.Id, beerDTO.BeerName, 
                    beerDTO.AlcByVol, beerDTO.Description, beerDTO.BeerType,
                    beerDTO.BeerTypeId, beerDTO.Brewery, beerDTO.BreweryId);

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
                var beerDto = new BeerDTO(model.BeerName, model.BeerTypeId, 
                    model.BreweryId, (double)model.AlcByVol, model.Description);
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
            var beerTypeId = model.BeerTypeId;
            var breweryId = model.BreweryId;
            beerService.UpdateBeer(id, beerName, alkByVol, descr, beerTypeId, breweryId);

            return Ok();
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
        public IActionResult Get(string type = null, string orderby = null)
        {
            var beers = this.beerService.FilterBeers(type, orderby)
             .Select(b => new BeerViewModel(b.Id, b.BeerName, b.AlcByVol, b.Description,
             b.BeerType, b.BeerTypeId, b.Brewery, b.BreweryId))
             .ToList();

            return Ok(beers);
        }


        [HttpPost]
        [Route("reviews")]
        public IActionResult PostReview([FromBody] ReviewViewModel model)
        {
            try
            {
                var newReview = reviewService.AddReview(model.UserName, model.BeerName, 
                    model.Rating, model.RMessage);

                var newReviewModel = new ReviewViewModel(newReview.RMessage, newReview.Rating,
                    newReview.User, newReview.UserId, newReview.Beer, 
                    newReview.BeerId, newReview.ReviewedOn);

                return Ok(newReviewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}