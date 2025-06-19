using DocumentAccessApprovalSystem.Domain.Enums;
using MediatR;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Commands.CreateAccessRequest
{
    public record CreateAccessRequestCommand(
        Guid RequestorId,
        Guid DocumentId,
        string Reason,
        AccessType AccessType) : IRequest<Guid>;
}