using System;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerOverflow.Web.ApiControllers
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService userService;

        public UserApiController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var userDTO = await this.userService.GetUserByIdAsync(id);

                var model = new UserViewModel(userDTO.Id, userDTO.Username,
                    userDTO.FirstName, userDTO.LastName, userDTO.Email, userDTO.CreatedOn);

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
            var users = await this.userService.GetAllUsersAsync();
            var usersVM = users.Select(u => new UserViewModel(u.Id, u.Username, u.FirstName, u.LastName, u.Email, u.CreatedOn))
                .ToList();

            return Ok(users);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] UserViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var userDTO = new UserDTO(model.Id, model.Username,
                model.FirstName, model.LastName, model.Email);

            var newUser = await this.userService.CreateUserAsync(userDTO);

            return Created("Post", newUser);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var user = await this.userService.UpdateUserAsync(id, model.Username,
                model.FirstName, model.LastName, model.Email);

            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var user = await this.userService.DeleteUserAsync(id);

            return Ok();
        }
    }

}
