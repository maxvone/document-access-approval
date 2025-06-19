using MediatR;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Commands.DecideOnRequest
{
	public record DecideOnRequestCommand(
		Guid AccessRequestId,
		Guid ApproverId,
		bool IsApproved,
		string Comment) : IRequest;
}