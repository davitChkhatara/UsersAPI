using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersApi.Application;
using UsersApi.Application.Users.Interfaces;
using UsersApi.Application.Users.Models;
using UsersApi.Domain.Entities.UserAggregate;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("user")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest request)
        {
            await _userService.CreateUser(request);
            return NoContent();
        }

        [HttpDelete]
        [Route("user")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            await _userService.DeleteUser(userName);
            return NoContent();
        }

        [HttpPost]
        [Route("user/login")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SignInUser(SignInUserRequest request)
        {
            await _userService.SignIn(request);
            return NoContent();
        }

        [HttpPut]
        [Route("user")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
        {
            await _userService.UpdateUser(request);
            return NoContent();
        }

        [HttpGet]
        [Route("user/{user-name}")]
        [ProducesResponseType(typeof(User),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateUser()
        {
            var userName = RouteData.Values["user-name"].ToString();
            return Ok(await _userService.GetUser(userName));
        }


    }
}
