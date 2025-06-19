using DocumentAccessApproval.Application.Features.AccessRequest.Commands.CreateAccessRequest;
using DocumentAccessApprovalSystem.Application.Abstractions;
using DocumentAccessApprovalSystem.Domain.Enums;
using MediatR;

namespace DocumentAccessApprovalSystem.Application.Features.AccessRequest.Commands.CreateAccessRequest
{
    public class CreateAccessRequestCommandHandler : IRequestHandler<CreateAccessRequestCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateAccessRequestCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAccessRequestCommand request, CancellationToken cancellationToken)
        {
            var accessRequest = new Domain.Entities.AccessRequest
            {
                Id = Guid.NewGuid(),
                RequestorId = request.RequestorId,
                DocumentId = request.DocumentId,
                Reason = request.Reason,
                RequestedAccessType = request.AccessType,
                Status = AccessRequestStatus.Pending,
                RequestDate = DateTime.UtcNow
            };

            _context.AccessRequests.Add(accessRequest);
            await _context.SaveChangesAsync(cancellationToken);

            return accessRequest.Id;
        }
    }
}