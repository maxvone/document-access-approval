using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Application.Features.AccessRequest.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Queries.GetMyAccessRequests
{
	public class GetMyAccessRequestsQueryHandler : IRequestHandler<GetMyAccessRequestsQuery, IEnumerable<AccessRequestDto>>
	{
		private readonly IApplicationDbContext _context;

		public GetMyAccessRequestsQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<AccessRequestDto>> Handle(GetMyAccessRequestsQuery request, CancellationToken cancellationToken)
		{
            List<AccessRequestDto> accessRequestDtos = await _context.AccessRequests
                .AsNoTracking()
                .Where(ar => ar.RequestorId == request.RequestorId)
                .OrderByDescending(ar => ar.RequestDate)
                .Select(ar => new AccessRequestDto
                {
                    Id = ar.Id,
                    DocumentName = ar.Document!.Name,
                    Status = ar.Status.ToString(),
                    RequestDate = ar.RequestDate,
                    DecisionComment = ar.Decision != null ? ar.Decision.Comment : null
                })
                .ToListAsync(cancellationToken);

            return accessRequestDtos;
		}
	}
}