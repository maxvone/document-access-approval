using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Application.Common;
using DocumentAccessApproval.Domain.Entities;
using MediatR;

namespace DocumentAccessApproval.Application.Features.AccessRequest.Commands.DecideOnRequest
{
    public class DecideOnRequestCommandHandler : IRequestHandler<DecideOnRequestCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly INotificationService _notificationService;

        public DecideOnRequestCommandHandler(IApplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task Handle(DecideOnRequestCommand request, CancellationToken cancellationToken)
        {
            var accessRequest = await _context.AccessRequests.FindAsync(new object[] { request.AccessRequestId }, cancellationToken)
                ?? throw new NotFoundException(nameof(AccessRequest), request.AccessRequestId);

            var decision = new Decision
            {
                Id = Guid.NewGuid(),
                AccessRequestId = request.AccessRequestId,
                ApproverId = request.ApproverId,
                IsApproved = request.IsApproved,
                Comment = request.Comment,
                DecisionDate = DateTime.UtcNow
            };

            // This method contains the core domain logic for processing a decision
            accessRequest.ProcessDecision(decision);

            _context.Decisions.Add(decision);

            await _context.SaveChangesAsync(cancellationToken);

            // Simulate sending a notification after the decision is saved
            await _notificationService.SendNotificationAsync(accessRequest);
        }
    }
}