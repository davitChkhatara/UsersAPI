using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersApi.Application.Users.Commands.CreateUser;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;
        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("user")]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
