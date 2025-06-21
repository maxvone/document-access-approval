using DocumentAccessApproval.Application.Features.Documents.Queries.Dtos;
using DocumentAccessApproval.Application.Features.Documents.Queries.GetAllDocuments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentAccessApproval.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DocumentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDocuments()
        {
            var query = new GetAllDocumentsQuery();
            var documents = await _mediator.Send(query);

            return Ok(documents);
        }
    }
}
