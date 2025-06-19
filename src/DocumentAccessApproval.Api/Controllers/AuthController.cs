using DocumentAccessApproval.Api.Dtos;
using DocumentAccessApproval.Application.Features.Auth.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentAccessApproval.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = new LoginCommand(request.Email, request.Password);

            string token = await _mediator.Send(command);

            return Ok(new { Token = token });
        }
    }
}
