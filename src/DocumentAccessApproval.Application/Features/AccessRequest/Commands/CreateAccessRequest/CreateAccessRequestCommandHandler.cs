using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Domain.Enums;
using MediatR;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Commands.CreateAccessRequest
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