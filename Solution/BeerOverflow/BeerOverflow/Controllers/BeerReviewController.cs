using System;
using System.Threading.Tasks;
using BeerOverflow.Data;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.Controllers
{
    public class BeerReviewController : Controller
    {
        private readonly IBeerService beerService;
        private readonly IReviewService reviewService;
        private readonly BeerOverflowContext _context;

        public BeerReviewController(BeerOverflowContext context, IBeerService beerService, IReviewService reviewService)
        {
            _context = context;
            this.beerService = beerService;
            this.reviewService = reviewService;
        }

        [HttpGet]
        //[Route("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            try
            {
                var brDTO = await reviewService.GetReviewAsync(id);
                var bDTO = await beerService.GetBeerAsync(brDTO.BeerId);
                var model = new BeerReviewEditViewModel(brDTO.Id, brDTO.RMessage, brDTO.User, bDTO.Id, bDTO.BeerName, bDTO.AlcByVol, bDTO.Description,
                                bDTO.BeerType, bDTO.Brewery, bDTO.AvgRating, brDTO.ReviewedOn, brDTO.DeletedOn);

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, RMessage, IsDeleted, BeerId")] BeerReviewEditViewModel model)
        {
            try
            {
                await this.reviewService.ModifyReviewAsync(model.Id, model.RMessage, model.IsDeleted);
                var Id = model.BeerId;
                return RedirectToAction("Details","Beers", new { Id });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}