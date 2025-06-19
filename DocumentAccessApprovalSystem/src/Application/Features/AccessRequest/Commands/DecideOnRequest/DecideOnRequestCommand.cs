using MediatR;

namespace DocumentAccessApprovalSystem.Application.Features.Commands.DecideOnRequest
{
	public record DecideOnRequestCommand(
		Guid AccessRequestId,
		Guid ApproverId,
		bool IsApproved,
		string Comment) : IRequest;
}