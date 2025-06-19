using DocumentAccessApproval.Api.Dtos;
using DocumentAccessApproval.Application.Features.AccessRequest.Commands.CreateAccessRequest;
using DocumentAccessApproval.Application.Features.AccessRequest.Commands.DecideOnRequest;
using DocumentAccessApproval.Application.Features.AccessRequest.Queries.Dtos;
using DocumentAccessApproval.Application.Features.AccessRequest.Queries.GetMyAccessRequests;
using DocumentAccessApproval.Application.Features.AccessRequest.Queries.GetPendingAccessRequests;
using DocumentAccessApproval.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DocumentAccessApproval.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccessRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccessRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = nameof(Role.User))]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAccessRequest([FromBody] CreateAccessRequestDto dto)
        {
            var command = new CreateAccessRequestCommand(GetCurrentUserId(), dto.DocumentId, dto.Reason, dto.AccessType);
            var requestId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMyRequests), new { id = requestId }, new { requestId });
        }

        [HttpGet("my-requests")]
        [Authorize(Roles = nameof(Role.User))]
        [ProducesResponseType(typeof(IEnumerable<AccessRequestDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMyRequests()
        {
            var query = new GetMyAccessRequestsQuery(GetCurrentUserId());
            var requests = await _mediator.Send(query);
            return Ok(requests);
        }

        [HttpGet("pending")]
        [Authorize(Roles = nameof(Role.Approver))]
        [ProducesResponseType(typeof(IEnumerable<PendingRequestDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPendingRequests()
        {
            var query = new GetPendingAccessRequestsQuery();
            var requests = await _mediator.Send(query);
            return Ok(requests);
        }

        [HttpPost("{requestId}/decide")]
        [Authorize(Roles = nameof(Role.Approver))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DecideOnRequest(Guid requestId, [FromBody] DecideRequestDto dto)
        {
            var command = new DecideOnRequestCommand(requestId, GetCurrentUserId(), dto.IsApproved, dto.Comment);
            await _mediator.Send(command);
            return NoContent();
        }

        private Guid GetCurrentUserId() =>
            Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }
}
