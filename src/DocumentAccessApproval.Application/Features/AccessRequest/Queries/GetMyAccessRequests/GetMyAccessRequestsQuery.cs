using MediatR;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Queries.GetMyAccessRequests
{
    public record GetMyAccessRequestsQuery(Guid RequestorId) : IRequest<IEnumerable<AccessRequestDto>>;
}