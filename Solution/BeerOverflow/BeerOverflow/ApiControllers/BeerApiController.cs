using System;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllBeers()
        {
            var beers = await this.beerService.GetAllBeersAsync();
            var beersVM = beers
                .Select(b => new BeerViewModel(b.Id, b.BeerName, b.AlcByVol,
                b.Description, b.BeerType, b.BeerTypeId,
                b.Brewery, b.BreweryId, b.AvgRating)).ToList();

            return Ok(beersVM);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var beerDTO = await beerService.GetBeerAsync(id);
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
        public async Task<IActionResult> Create([FromBody] BeerViewModel model)
        {
            try
            {
                var beerDto = new BeerDTO(model.BeerName, model.BeerTypeId,
                    model.BreweryId, (double)model.AlcByVol, model.Description);
                var beer = await this.beerService.CreateBeerAsync(beerDto);

                return Created("Post", beer);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BeerViewModel model)
        {
            var beerName = model.BeerName;
            var alkByVol = model.AlcByVol;
            var descr = model.Description;
            var beerTypeId = model.BeerTypeId;
            var breweryId = model.BreweryId;
            await this.beerService.UpdateBeerAsync(id, beerName, alkByVol, descr, beerTypeId, breweryId);

            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.beerService.DeleteBeerAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> Get(string type = null, string orderby = null)
        {
            var beers = await this.beerService.FilterBeersAsync(type, orderby);
            var beersVM = beers.Select(b => new BeerViewModel(b.Id, b.BeerName, b.AlcByVol, b.Description,
             b.BeerType, b.BeerTypeId, b.Brewery, b.BreweryId, b.AvgRating))
             .ToList();

            return Ok(beers);
        }


        //[HttpPost]
        //[Route("reviews")]
        //public IActionResult PostReview([FromBody] ReviewViewModel model)
        //{
        //    try
        //    {
        //        var newReview = reviewService.AddReview(model.UserName, model.BeerName,
        //            model.Rating, model.RMessage);

        //        var newReviewModel = new ReviewViewModel(newReview.RMessage, newReview.Rating,
        //            newReview.User, newReview.UserId, newReview.Beer,
        //            newReview.BeerId, newReview.ReviewedOn);

        //        return Ok(newReviewModel);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //}
    }
}