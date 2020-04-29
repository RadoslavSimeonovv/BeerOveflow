using System;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/userbeers")]
    [ApiController]
    public class UserBeersController : ControllerBase
    {
        private readonly IUserBeersService userBeersService;
        public UserBeersController(IUserBeersService userBeersService)
        {
            this.userBeersService = userBeersService;
        }

        [HttpPost]
        [Route("wishlist")]
        public async Task<IActionResult> PostWishList([FromBody] UserBeersViewModel model)
        {
            try
            {
                var userBeers = await userBeersService.AddBeerToWishListAsync(model.User, model.Beer);

                var userBeersModel = new UserBeersViewModel(userBeers.User, userBeers.UserId,
                    userBeers.Beer, userBeers.BeerId);

                return Ok(userBeersModel);
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("dranklist")]
        public async Task<IActionResult> PostDrankList([FromBody] UserBeersViewModel model)
        {
            try
            {
                var userBeers = await userBeersService.AddBeerToDrankListAsync(model.User, model.Beer);

                var userBeersModel = new UserBeersViewModel(userBeers.User, userBeers.UserId,
                    userBeers.Beer, userBeers.BeerId, userBeers.DrankOn);

                return Ok(userBeersModel);
            }
            catch (Exception)
            {
                return BadRequest("Already exists!");
            }
        }

        [HttpGet]
        [Route("wishlist/{userName}")]
        public async Task<IActionResult> GetWishList(string userName)
        {
            try
            {
                var userBeersDTO = await userBeersService.GetUserWishListAsync(userName);
                var modelUserBeers = userBeersDTO
                    .Select(ub => new UserBeersViewModel(ub.User, ub.UserId,
                     ub.Beer, ub.BeerId));

                return Ok(modelUserBeers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("dranklist/{userName}")]
        public async Task<IActionResult> GetDrankList(string userName)
        {
            try
            {
                var userBeersDTO = await userBeersService.GetUserDrankListAsync(userName);
                var modelUserBeers = userBeersDTO
                    .Select(ub => new UserBeersViewModel(ub.User, ub.UserId,
                     ub.Beer, ub.BeerId, ub.DrankOn));

                return Ok(modelUserBeers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}