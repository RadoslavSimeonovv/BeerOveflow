using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using BeerOverflow.Services.Providers.Contracts;
using BeerOverflow.Web.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Get(int id)
        {
            try
            {
                var userDTO = this.userService.GetUserById(id);

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
        public IActionResult Get()
        {
            var users = this.userService.GetAllUsers()
                .Select(u => new UserViewModel(u.Id, u.Username, u.FirstName, u.LastName, u.Email, u.CreatedOn))
                .ToList();

            return Ok(users);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] UserViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var userDTO = new UserDTO(model.Id, model.Username,
                model.FirstName, model.LastName, model.Email);

            var newUser = this.userService.CreateUser(userDTO);

            return Created("Post", newUser);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] UserViewModel model)
        {
            if (id == 0 || model == null)
            {
                return BadRequest();
            }
            var user = this.userService.UpdateUser(id, model.Username, 
                model.FirstName, model.LastName, model.Email);

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

            var user = this.userService.DeleteUser(id);

            return Ok();
        }
    }

}
