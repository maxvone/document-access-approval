using MediatR;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Queries.GetPendingAccessRequests
{
    public record GetPendingAccessRequestsQuery() : IRequest<IEnumerable<PendingRequestDto>>;
}