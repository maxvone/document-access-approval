using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Queries.GetPendingAccessRequests
{
    public class GetPendingAccessRequestsQueryHandler : IRequestHandler<GetPendingAccessRequestsQuery, IEnumerable<PendingRequestDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPendingAccessRequestsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PendingRequestDto>> Handle(GetPendingAccessRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _context.AccessRequests
                .AsNoTracking()
                .Where(ar => ar.Status == AccessRequestStatus.Pending)
                .OrderBy(ar => ar.RequestDate)
                .Select(ar => new PendingRequestDto
                {
                    RequestId = ar.Id,
                    DocumentName = ar.Document!.Name,
                    RequestorEmail = ar.Requestor!.Email,
                    Reason = ar.Reason,
                    RequestedAccessType = ar.RequestedAccessType.ToString(),
                    RequestDate = ar.RequestDate
                })
                .ToListAsync(cancellationToken);
        }
    }
}
