using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using BeerOverflow.Services.DTO_s;

namespace BeerOverflow.Web.Controllers
{

    public class BeersController : Controller
    {
        private readonly IBeerService beerService;
        private readonly IReviewService reviewService;
        private readonly BeerOverflowContext _context;

        public BeersController(BeerOverflowContext context, IBeerService beerService, IReviewService reviewService)
        {
            _context = context;
            this.beerService = beerService;
            this.reviewService = reviewService;
        }

        // GET: Beers
        public async Task<IActionResult> Index()
        {
            //var beerOverflowContext = _context.Beers.Include(b => b.BeerType).Include(b => b.Brewery).Include(b => b.Country);
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
            return View(models);
        }

        // GET: Beers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Beers/Create
        public IActionResult Create()
        {
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Description");
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Description");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeerName,AlcByVol,Description,CountryId,BeerTypeId,BreweryId")] BeerDTO beer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Type", beer.BeerTypeId);
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name", beer.BreweryId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", beer.CountryId);
            return View(beer);
        }

        // GET: Beers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Description", beer.BeerTypeId);
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Description", beer.BreweryId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", beer.CountryId);
            return View(beer);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BeerName,AlcByVol,Description,DateUnlisted,CountryId,BeerTypeId,BreweryId")] Beer beer)
        {
            if (id != beer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerExists(beer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeerTypeId"] = new SelectList(_context.BeerTypes, "Id", "Description", beer.BeerTypeId);
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Description", beer.BreweryId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", beer.CountryId);
            return View(beer);
        }

        // GET: Beers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers
                .Include(b => b.BeerType)
                .Include(b => b.Brewery)
                .Include(b => b.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerExists(int id)
        {
            return _context.Beers.Any(e => e.Id == id);
        }
    }
}
