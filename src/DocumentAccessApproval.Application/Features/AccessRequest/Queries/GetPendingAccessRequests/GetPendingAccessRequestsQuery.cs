using DocumentAccessApproval.Application.Features.AccessRequest.Queries.Dtos;
using MediatR;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Queries.GetPendingAccessRequests
{
    public record GetPendingAccessRequestsQuery() : IRequest<IEnumerable<PendingRequestDto>>;
}