using MediatR;

namespace DocumentAccessApprovalSystem.Application.Features.AccessRequest.Queries.GetMyAccessRequests
{
    public record GetMyAccessRequestsQuery(Guid RequestorId) : IRequest<IEnumerable<AccessRequestDto>>;
}